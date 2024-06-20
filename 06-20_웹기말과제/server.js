const bodyParser = require("body-parser");
const express = require("express");
const session = require("express-session"); // npm i express-session
const mysql = require("mysql2"); // npm i mysql2
const app = express();
const bcrypt = require("bcryptjs");

const port = 80;
app.set("view engine", "ejs");
// app.use(bodyParser.json());
// form submit post로 받기 설정
app.use(express.urlencoded({ extended: true }));

// MySQL 연결 설정
const connection = mysql.createConnection({
  host: "localhost",
  user: "root", // MySQL 사용자 이름
  password: "1234", // MySQL 비밀번호
  database: "new_schema", // 사용할 데이터베이스 이름
});

// MySQL 연결
connection.connect((err) => {
  if (err) {
    console.error("MySQL 연결 실패:", err);
    return;
  }
  console.log("MySQL 연결 성공");
});

// express-session 설정
app.use(
  session({
    secret: "454564684654", // 세션 암호화에 사용되는 키
    resave: false, // 세션이 수정되지 않아도 다시 저장할지 여부
    saveUninitialized: false, // 초기화되지 않은 세션을 저장할지 여부
    cookie: { maxAge: 3600000 }, // 쿠키의 유효 기간 설정 (밀리초 단위)
  })
);

app.get("/", (req, res) => {
  posts = []; // todo: DB에서 post목록 데이터를 조회해야함
  const sql = `SELECT no, title, reg_user_id, user.nickname, DATE_FORMAT(reg_dt, '%Y-%m-%d %H:%i:%s') as regdt FROM post JOIN user ON user.id = post.reg_user_id ORDER BY no DESC`;
  connection.query(sql, (err, posts) => {
    res.render("index", { posts, user: req.session.user });
  });
});

app.get("/join", (req, res) => {
  res.render("join", {});
});

// 회원 등록
app.post("/join", async (req, res) => {
  const salt = await bcrypt.genSalt(10);
  const newData = req.body;
  const password = await bcrypt.hash(newData.pw, salt);
  const sql = "INSERT INTO user (id, pw, nickname, email) VALUES (?, ?, ?, ?)";
  const values = [newData.id, password, newData.nickname, newData.email];

  connection.query(sql, values, (err, result) => {
    if (err) {
      console.error("데이터베이스 오류:", err);
      return res.status(500).send("서버 오류");
    }
    // 그냥 바로 html을 보낼 수 있음 아니면 예쁜 페이지 하나를 만들어서 그걸 보내도 됨
    const resultHtml = `<script>
            alert('회원등록이 완료되었습니다');
            location.href = '/';
        </script>`;
    res.status(201).send(resultHtml);
  });
});

// 로그인 페이지
app.get("/login", (req, res) => {
  res.render("login");
});

// 세션 로그인
app.post("/login", async (req, res) => {
  console.log(req.body);
  // 1. id에 해당하는 유저 정보를 db에서 꺼냄
  const sql = `SELECT * FROM user WHERE id = ?`;

  // 연결된 db에 쿼리를 실행
  connection.query(sql, [req.body.id], (err, user) => {
    if (err) {
      console.error("데이터베이스 오류:", err);
      return res.status(503).send("서버 오류");
    }
    if (!user || user.length === 0) {
      const resultHtml = `<script>
            alert('사용자 정보를 찾을 수 없습니다');
            location.href = '/login';
        </script>`;
      return res.status(403).send(resultHtml);
    }
    user = user[0];
    // 유저정보
    console.log(user);
    // 2. 로그인pw, 유저 정보의 hash되어 있는 pw 검증
    if (bcrypt.compare(req.body.pw, user.pw)) {
      // 3. 정보가 확인되면 (인증 성공) 세션 발급
      req.session.user = user;
      res.redirect("/");
    } else {
      //   - 인증실패, 에러화면 or 로그인화면 다시 redirect
      const resultHtml = `<script>
            alert('사용자 정보를 찾을 수 없습니다');
            location.href = '/login';
        </script>`;
      return res.status(403).send(resultHtml);
    }
  });
});

// 로그아웃
app.get("/logout", (req, res) => {
  // 콜백함수있음. 세션 삭제 완료되면 메인이동
  req.session.destroy(() => {
    res.redirect("/");
  });
});

// 글작성
app.get("/form", (req, res) => {
  res.render("form");
});

app.post("/post", (req, res) => {
  // req.body.subject title content
  const post = req.body;
  const sql =
    "INSERT INTO post (subject, title, content, reg_dt, reg_user_id) VALUES (?, ?, ?, now(), ?)";
  const values = [post.subject, post.title, post.content, req.session.user.id];

  connection.query(sql, values, (err, result) => {
    if (err) {
      console.error("데이터베이스 오류:", err);
      return res.status(500).send("서버 오류");
    }
    // 그냥 바로 html을 보낼 수 있음 아니면 예쁜 페이지 하나를 만들어서 그걸 보내도 됨
    const resultHtml = `<script>
            alert('게시글등록완료');
            location.href = '/';
        </script>`;
    res.status(201).send(resultHtml);
  });
  // req.sseion.user 의 user id를 외래키로 집어넣고 datatime에 현재 시간을 넣어야함
  // post 테이블에 insert
});

// 글 삭제
app.post('/delete', (req, res) => {
    const userId = req.session.user.id
    const sql = `DELETE FROM post WHERE no = ? AND reg_user_id = ?`
    connection.query(sql, [req.body.no, userId], (err, result)=>{
        res.redirect('/')
    })
})

// 글 상세 조회
app.get('/posts/:no', (req, res) => {
    const no = req.params.no;
    console.log(no)
    const sql = `SELECT * FROM post WHERE no = ?`;
    connection.query(sql, [no], (ree, post) => {
        res.render('detail', {post : post[0]})
    });
})

app.listen(port, () => {
  console.log(`서버 실행중: http://localhost:${port}`);
});

const express = require('express');
const session = require('express-session'); // npm i express-session
const bcrypt = require("bcryptjs")
const app = express();
const port = 80;
const user_db = [] // db 대신 임시로 전역변수에 데이터 저장

app.use(express.json());
// cookie-parser 사용.
app.use(express.urlencoded({ extended: true })); // html form 요청 사용
app.set('view engine', 'ejs');

// express-session 설정
app.use(session({
  secret: '454564684654', // 세션 암호화에 사용되는 키
  resave: false, // 세션이 수정되지 않아도 다시 저장할지 여부
  saveUninitialized: false, // 초기화되지 않은 세션을 저장할지 여부
  cookie: { maxAge: 3600000 } // 쿠키의 유효 기간 설정 (밀리초 단위, 여기서는 1분)
}));

// 메인
app.get('/', (req, res) => {
  const username = req.session.username;
  console.log(user_db);
  const loginUser = user_db.find(d => d.username === req.body.username);
  res.render('main', {username, loginUser})
});
 
app.get('/login', (req, res) => {
  res.render('login');
})

app.post('/login',async (req, res) => {
  // 로그인 처리 - 세션 버전
  console.log(req.body);
  const loginUser = user_db.find(d => d.username === req.body.username);
  const check = await bcrypt.compare(req.body.password, loginUser.password)

  if (loginUser && check){
    req.session.username = req.body.username;
    res.redirect('/')
  } else {
    // 로그인 실패
    res.send('로그인실패');
  }
})

app.get('/logout', (req, res) => {
  req.session.destroy();
  res.redirect('/')
})

app.get('/join', async (req, res) => {
  // const salt = await bcrypt.genSalt(10)
  // let code = await bcrypt.hash('1234', salt)
  // res.send({'암호': code})
  res.render('join')
})

app.post('/join',async (req, res) => {
  const username = req.body.username;
  const salt = await bcrypt.genSalt(10)
  const password = await bcrypt.hash(req.body.password, salt);
  user_db.push({username, password})
  console.log(user_db)
  res.redirect('/')
  // const salt = await bcrypt.genSalt(10)
  // let code = await bcrypt.hash('1234', salt)
  // res.send({'암호': code})
})

// ----------------------------예시----------------------

// 세션 설정 예시
app.get('/set-session', (req, res) => {
  req.session.username = 'FirstCoding';
  res.send('세션 설정됨');
});

// 세션 읽기 예시
app.get('/get-session', (req, res) => {
  const username = req.session.username;
  if (username) {
    res.send(`저장된 세션: ${username}`);
  } else {
    res.send('설정된 세션 없음');
  }
});

// 세션 삭제 예시
app.get('/clear-session', (req, res) => {
  req.session.destroy(err => {
    if (err) {
      return res.send('세션 삭제 오류.');
    }
    res.send('세션 삭제됨.');
  });
});

app.listen(port, () => {
  console.log(`서버 실행 중: http://localhost:${port}`);
});
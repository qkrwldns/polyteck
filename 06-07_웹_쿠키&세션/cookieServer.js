const express = require('express');
const cookieParser = require('cookie-parser'); // npm i cookie-parser

const app = express();
const port = 80;

app.use(express.json());
// cookie-parser 사용.
app.use(cookieParser());
app.use(express.urlencoded({ extended: true })); // html form 요청 사용
app.set('view engine', 'ejs');


// 메인
app.get('/', (req, res) => {
  const username = req.cookies.username;
  
  res.render('main', {username})
});

app.get('/login', (req, res) => {
  res.render('login');
})

app.get('/logout', (req, res) => {
  res.clearCookie('username');
  res.redirect('/')
})

app.post('/login', (req, res) => {
  // 로그인 처리 - cookie 버전
  // 사용자 정보를 cookie에 세팅
  console.log(req.body);
  // 
  if (req.body.username == 'jiwoon' && req.body.password == '1234'){
    res.cookie('username', 'Jiwoon', { maxAge: 3600000, httpOnly: true });
    res.redirect('/')
  } else {
    // 로그인 실패
    res.send('로그인실패');
  }
})

// ----------------------------예시----------------------

// 쿠키 설정 예시
app.get('/set-cookie', (req, res) => {
  res.cookie('username', 'Jiwoon', { maxAge: 60000, httpOnly: true });
  res.send('쿠키가 설정됨.');
});

// 쿠키 읽기 예시
app.get('/get-cookie', (req, res) => {
  const username = req.cookies.username;
  if (username) {
    res.send(`저장된 쿠키: ${username}`);
  } else {
    res.send('설정된 쿠키 없음.');
  }
});

// 쿠키 삭제 예시
app.get('/clear-cookie', (req, res) => {
  res.clearCookie('username');
  res.send('쿠키 삭제 완료.');
});

app.listen(port, () => {
  console.log(`서버 실행 중: http://localhost:${port}`);
});

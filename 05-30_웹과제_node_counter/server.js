const express = require('express');
const app = express();
const port = 80;
let count = 0;
app.set('view engine', 'ejs');
app.use(express.json()); 
app.listen(port, () =>{
    console.log(`서버 실행중: http://localhost:${port}`);
});
app.get('/', (req, res) => {
    res.render('main', { count });
});
app.put('/count', (req, res) => {
    // 시도
    try {
        // 만약 undefined 아니라면 받아온 데이터로 count 변수에 저장
        if (req.body.count !== undefined) {
            count = req.body.count;
        } 
        // undefined 라면 그냥 1 증가
        else {
            count++;
        }
        res.json({ count });
    } 
    // 시도가 실패했을시 
    catch (error) {
        res.status(400).json({ error: 'json 형식이 아님' });
    }
});
app.delete('/count', (req, res) => {
    count = 0;
    res.json({"result":"OK", count });
});

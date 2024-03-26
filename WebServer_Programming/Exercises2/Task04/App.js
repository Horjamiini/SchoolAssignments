const express = require('express')
const albums = require('./routes/albums')
const path = require('path')
const app = express()

app.use(express.json())

app.use(express.static('./public'))


app.use('/api/albums', albums)

app.get('/', (req,res) => {
    res.sendFile(path.resolve(__dirname, './public/index.html'))
})

const PORT = 5001
app.listen(PORT, () => {
    console.log(`Server listening on port ${PORT}`)
})
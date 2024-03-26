const express = require('express')
const albums = require('./routes/albums')
const app = express()

app.use(express.json())

app.use('/api/albums', albums)


const PORT = 5001
app.listen(PORT, () => {
    console.log(`Server listening on port ${PORT}`)
})
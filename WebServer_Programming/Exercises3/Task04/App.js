require('dotenv').config()
const connectMongoDB = require('./db/mongodb')
const express = require('express')
const app = express()
const path = require('path')
const albums = require('./routes/albums')

app.use(express.json())
app.use('/api/albums', albums)
app.use(express.static('./public'))


const PORT = 5001
const start = async () => {
    try {
        await connectMongoDB(process.env.CONN_STRING)
        app.listen(PORT, () => console.log(`Server listening on port ${PORT}`))
    }
    catch (error) {
        console.log(error)
    }
}

start()


require('dotenv').config()
require('express-async-errors')

const express = require('express')
const app = express()

const connectMongoDB = require('./db/mongodb')
const albums = require('./routes/albums')

const errorHandlerMiddleware = require('./middleware/errorhandler')
const notFoundMiddleware = require('./middleware/notFound')

app.use(express.json())

app.use('/api/albums', albums)
app.use(express.static('./public'))

app.use(notFoundMiddleware)
app.use(errorHandlerMiddleware)


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


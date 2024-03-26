require('dotenv').config()
require('express-async-errors')

const express = require('express')
const app = express()

const connectMongoDB = require('./db/mongodb')
const albums = require('./routes/albums')
const register = require('./routes/register')

const errorHandlerMiddleware = require('./middleware/errorhandler')
const notFoundMiddleware = require('./middleware/notFound')

app.use(express.json())

app.use('/api/albums', albums)
app.use('/api/register', register)
app.use(express.static('./public'))

app.use(notFoundMiddleware)
app.use(errorHandlerMiddleware)


const PORT = process.env.PORT
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


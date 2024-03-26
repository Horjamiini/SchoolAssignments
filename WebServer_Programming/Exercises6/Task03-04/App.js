require('dotenv').config()
require('express-async-errors')

const express = require('express')
const app = express()

const connectMongoDB = require('./db/mongodb')
const { PORT, CONN_STRING } = process.env

const albums = require('./routes/albums')
const users = require('./routes/users')
const login = require('./routes/login')


const errorHandlerMiddleware = require('./middleware/errorhandler')
const notFoundMiddleware = require('./middleware/notFound')

app.use(express.static('./public'))
app.use(express.urlencoded({ extended: false }))
app.use(express.json())

app.use('/api/albums', albums)
app.use('/api/users', users)
app.use('/api/login', login)


app.use(notFoundMiddleware)
app.use(errorHandlerMiddleware)


const start = async () => {
    try {
        await connectMongoDB(CONN_STRING)
        app.listen(PORT, () => console.log(`Server listening on port ${PORT}`))
    }
    catch (error) {
        console.log(error)
    }
}

start()


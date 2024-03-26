require('express-async-errors')
const config = require('./utils/config')

const express = require('express')
//const connectMongoDB = require('./db/mongodb')
const mongoose = require('mongoose')
const path = require('path')
const session = require('express-session')
const MongoDBStore = require('connect-mongodb-session')(session)
const passport = require('passport')

const albums = require('./routes/albums')
const users = require('./routes/users')
const indexRouter = require('./routes/index')
const authRouter = require('./routes/auth')


const errorHandlerMiddleware = require('./middleware/errorhandler')
const notFoundMiddleware = require('./middleware/notFound')

const app = express()

app.use(express.json())
app.use(express.urlencoded({ extended: false }))
app.use(express.static(path.join(__dirname,'public')))
app.use(session({
    name: 'session_id',
    secret: config.SESSION_SECRET,
    resave: false,
    saveUninitialized: false,
    store: new MongoDBStore({
        uri: config.MONGODB_URI,
        collection: 'passport-sessions',
    })
}))


app.use(passport.authenticate('session'))
app.use('/',indexRouter)
app.use('/',authRouter)
app.use('/api/albums', albums)
app.use('/api/users', users)


app.use(notFoundMiddleware)
app.use(errorHandlerMiddleware)


mongoose.connect(config.MONGODB_URI)
    .then(() => {
        console.log('connect to MongoDB')
    })
    .catch((error) => {
        console.log('error connection to MongoDB:', error.message)
    })

module.exports = app
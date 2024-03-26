require('dotenv').config()

const PORT = process.env.PORT
const MONGODB_URI = process.env.CONN_STRING
const SESSION_SECRET = process.env.SESSION_SECRET

module.exports = {
    MONGODB_URI,
    PORT,
    SESSION_SECRET
}
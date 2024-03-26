require('dotenv').config()

const PORT = process.env.PORT

const MONGODB_URI = process.env.NODE_ENV === 'test'
    ? process.env.TEST_CONN_STRING
    : process.env.CONN_STRING

const SESSION_SECRET = process.env.SESSION_SECRET

const TEST_ID = process.env.TEST_ID

module.exports = {
    MONGODB_URI,
    PORT,
    SESSION_SECRET,
    TEST_ID
}
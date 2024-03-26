
const jwt = require('jsonwebtoken')
const { UnauthenticatedError } = require('../errors')

const authUser =  async (req, res, next) => {
    const authHeader = req.headers.authorization
    if(!authHeader || !authHeader.startsWith('Bearer')) {
        throw new UnauthenticatedError('No token or invalid token in header')
    }
    const token = authHeader.split(' ')[1]

    const decoded = jwt.verify(token,process.env.ACCESS_TOKEN_SECRET)
    const { id, username } = decoded
    req.user = { id,username }
    next()
}

module.exports = authUser

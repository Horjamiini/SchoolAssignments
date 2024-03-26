const jwt = require('jsonwebtoken')
const bryptjs = require('bcryptjs')
const User = require('../models/Users')
const { UnauthenticatedError } = require('../errors')
const { StatusCodes } = require('http-status-codes')

const login = async (req,res) => {
    const { username, password } = req.body
    const user = await User.findOne({ username })
    
    const pwdcorrect = user === null ? false : await bryptjs.compare(password, user.passwordHash)
    if (!(user && pwdcorrect)) {
        throw new UnauthenticatedError('Invalid username or password!')
    }

    const userForToken = {
        username: user.username,
        id: user._id
    }

    const token = jwt.sign(userForToken, process.env.ACCESS_TOKEN_SECRET, {expiresIn: process.env.JWT_EXPIRES_IN})
    res.status(StatusCodes.OK).send({ token, username: user.username})
}

module.exports = login
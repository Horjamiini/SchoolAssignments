const User = require('../models/Users')
const bcryptjs = require('bcryptjs')
const { StatusCodes } = require('http-status-codes')
const { NotFoundError } = require('../errors')
const { ConflictError } = require('../errors')
const { BadRequestError } = require('../errors')


const getUsers = async(req,res) => {
    const users = await User.find({})
    res.status(200).json({ users })
}

const getSingleUser = async (req,res) => {
    const { id } = req.params
    const user = await User.findById(id)
    if (!user) {
        throw new NotFoundError('User not found!')
    }
    res.status(StatusCodes.OK).json({ user })
}

const registerUser = async (req,res) => {
    const { username, email, password, pwdconfig } = req.body
    const userExists = await User.findOne({ email })
    if (userExists) {
        throw new ConflictError(`User with ${email} already exists`)
    }
    if (!(username || email || password || pwdconfig))
    {
        throw new BadRequestError('You have to fill all the information')
    }
    if (password != pwdconfig) {
        throw new BadRequestError('Password do not match')
    }

    const saltRounds = 10
    const passwordHash = await bcryptjs.hash(password,saltRounds)
    const user = new User({
        username,
        email,
        passwordHash,
    })

    await user.save()
    res.status(StatusCodes.CREATED).json({ user })
}

module.exports = {
    getUsers,
    getSingleUser,
    registerUser
}
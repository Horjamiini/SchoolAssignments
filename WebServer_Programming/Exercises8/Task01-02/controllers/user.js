const User = require('../models/Users')
const bcryptjs = require('bcryptjs')
const { StatusCodes } = require('http-status-codes')
const { NotFoundError, UnauthorizedError, ConflictError, BadRequestError } = require('../errors')


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
    const { username, email, password, pwdconfig, role } = req.body
    const userExists = await User.findOne({ email })
    if (userExists) {
        throw new ConflictError(`User with ${email} already exists`)
    }
    if (!(username || email || password || pwdconfig))
    {
        throw new BadRequestError('You have to fill all the information')
    }
    if (password !== pwdconfig) {
        throw new UnauthorizedError('Passwords do not match')
    }

    const saltRounds = 10
    const passwordHash = await bcryptjs.hash(password,saltRounds)
    const user = new User({
        username,
        email,
        passwordHash,
        role
    })

    await user.save()
    res.redirect('/')

}

const deleteUser = async (req,res) => {
    const { id } = req.params
    const user = await User.findById(id)
    if(!user) {
        throw new NotFoundError('User not found')
    }
    const deletedUser = await User.findByIdAndDelete(id)
    res.status(StatusCodes.OK).json({ deletedUser })
}

module.exports = {
    getUsers,
    getSingleUser,
    registerUser,
    deleteUser
}
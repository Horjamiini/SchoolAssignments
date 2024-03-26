const { Vehicle, User } = require('../models/index')
const { StatusCodes } = require('http-status-codes')

const getUsers = async (req,res) => {
    const users = await User.findAll({
        attributes: {exclude: ['username']},
        include: {
            model: Vehicle,
            attributes: {exclude: ['userId']}
        }
    })
    res.status(StatusCodes.OK).json({ success:true, data:users })
}

const getSingleUser = async (req,res) => {
    const user = req.user
    res.status(StatusCodes.OK).json({ success:true,data:user})
}

const createUser = async (req,res) => {
    const { username, name } = req.body
    const user = await User.create({ username, name })
    return res.status(StatusCodes.CREATED).json({ success:true, data:user })
}

module.exports = {
    getUsers,
    getSingleUser,
    createUser
}
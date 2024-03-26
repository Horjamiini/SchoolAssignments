const User = require('../models/Users')
const bcryptjs = require('bcryptjs')

const getUsers = async(req,res) => {
    const users = await User.find({})
    res.status(200).json({ users })
}

const registerUser = async (req,res) => {
    const { name, email, password, pwdconfig } = req.body
    const userExists = await User.findOne({ email })
    if (userExists) {
        return res.status(409).send({ success: false, msg:`User ${email} already exists`})
    }

    const saltRounds = 10
    const passwordHash = await bcryptjs.hash(password,saltRounds)
    const passwordConfirmationHash = await bcryptjs.hash(pwdconfig,saltRounds)
    if (password != pwdconfig) {
        return res.status(500).send({ success:false, msg:'Password and confirmation dont match!' })
    }
    const user = new User({
        name,
        email,
        passwordHash,
        passwordConfirmationHash
    })

    await user.save()
    res.status(201).json({ user })
}

module.exports = {
    getUsers,
    registerUser
}
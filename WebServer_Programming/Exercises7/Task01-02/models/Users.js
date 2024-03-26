const mongoose = require('mongoose')

const roles = ['admin', 'user']


const userSchema = new mongoose.Schema({
    username: {
        type: String,
        required: [true, 'User must have a name']
    },
    email: {
        type: String,
        required: [true, 'User must have an email']
    },
    passwordHash: String,
    role: { 
        type:String,
        required: [true, 'User must have a role'],
        enum: roles,
        default: 'user'
    }
})

const User = mongoose.model('User', userSchema)

module.exports = User
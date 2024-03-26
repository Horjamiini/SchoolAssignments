const mongoose = require('mongoose')
// eslint-disable-next-line no-unused-vars
const { Schema } = mongoose

const userSchema = new mongoose.Schema({
    name: {
        type: String,
        required: [true, 'User must have a name']
    },
    email: {
        type: String,
        required: [true, 'User must have an email']
    },
    passwordHash: String,
    passwordConfirmationHash: String

})

const User = mongoose.model('User', userSchema)

module.exports = User
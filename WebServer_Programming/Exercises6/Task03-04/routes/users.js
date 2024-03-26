const express = require('express')
const router = express.Router()

const {
    getUsers,
    getSingleUser,
    registerUser
} = require('../controllers/user')

router.get('/',getUsers)
router.get('/:id',getSingleUser)
router.post('/register',registerUser)

module.exports = router
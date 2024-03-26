const express = require('express')
const router = express.Router()
const findUser = require('../middleware/findUser')

const {
    getUsers,
    getSingleUser,
    createUser
} = require('../controllers/users')

router.get('/',getUsers)
router.get('/:id',getSingleUser,findUser)
router.post('/',createUser)

module.exports = router
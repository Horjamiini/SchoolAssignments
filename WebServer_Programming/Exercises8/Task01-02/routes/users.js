const express = require('express')
const router = express.Router()

const {authUser, authPerms} = require('../middleware/auth')

const {
    getUsers,
    getSingleUser,
    registerUser,
    deleteUser
} = require('../controllers/user')


// get and delete routes will only work if useris logged in
// and has role 'admin'
router.get('/',[authUser, authPerms('admin')],getUsers)
router.get('/:id',[authUser, authPerms('admin')], getSingleUser)
router.post('/register',registerUser)
router.delete('/:id',[authUser, authPerms('admin')],deleteUser)

module.exports = router
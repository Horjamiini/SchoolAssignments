const express = require('express')
const router = express.Router()
const passport = require('passport')
const LocalStrategy = require('passport-local')
const bcryptjs = require('bcryptjs')
const User = require('../models/Users')

passport.use(new LocalStrategy(async function verify(username,password,cb){
    try {
        const user = await User.findOne({ username })
        const passwordCorrect = user === null ? false : await bcryptjs.compare(password, user.passwordHash)
        if (!(user && passwordCorrect)) {
            return cb(null,false, {message: 'Incorrect username or password'})
        }
        return cb(null,user)
    }
    catch (err) {
        return cb(err)
    }
}))

passport.serializeUser(function(user,cb){
    process.nextTick(function(){
        cb(null, {id: user.id, username:user.username, role:user.role})
    })
})

passport.deserializeUser(function(user,cb) {
    process.nextTick(function(){
        return cb(null,user)
    })
})


router.get('/login', (req,res) => {
    res.redirect('/login.html')
})

router.post('/login/password',passport.authenticate('local', {
    successRedirect: '/',
    failureRedirect: '/login'
}))

router.post('/logout', (req, res, next) => {
    req.logout( (err) => {
        if (err) { return next(err) }
        res.redirect('/login')
    })
})
  

module.exports = router
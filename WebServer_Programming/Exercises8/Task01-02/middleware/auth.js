const { StatusCodes } = require('http-status-codes')
const { UnauthenticatedError, APIError } = require('../errors')

// Check that user has logged in -> passport
const authUser =  async (req, res, next) => {
    if(process.env.NODE_ENV !== 'test' && !req.user){
        throw new UnauthenticatedError('Not logged in!')
    }
    next()
}

//Check for users roles
const authPerms = (...roles) => {
    return (req,res,next) => {
        if(!roles.includes(req.user.role)) {
            throw new APIError('Unauthorized to access this route', StatusCodes.FORBIDDEN)
        }
        next()
    }
}
module.exports = { authUser, authPerms }
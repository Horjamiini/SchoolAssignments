const { APIError } = require('../errors/apierror')
// eslint-disable-next-line no-unused-vars
const errorHandler = (err, req, res, next) => {
    if(err instanceof APIError) {
        return res.status(err.statusCode).json({ msg: err.message })
    }
    return res.status(500).json({ msg: 'There was an error, please try again' })
}

module.exports = errorHandler
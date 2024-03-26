const { StatusCodes } = require('http-status-codes')
const APIError = require('./apierror')

class ConflictError extends APIError {
    constructor(message) {
        super(message)
        this.statusCode = StatusCodes.CONFLICT
    }
}

module.exports = ConflictError
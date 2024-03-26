const notFound = (req, res, next) => {
    res.status(404).send('Unknown endpoint!')
    next()
}
module.exports = notFound
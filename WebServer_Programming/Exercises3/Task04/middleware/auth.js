const auth = (req, res, next) => {
    console.log('Query:', req.query)
    const { search } = req.query
    
    if (search !== 'user') {
        return res
        .status(400)
        .json(({success:false,msg: `Unauthorized`}))
    }
    
    res.status(200)
    next()
}

module.exports = auth

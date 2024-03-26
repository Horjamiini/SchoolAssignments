const mongoose = require('mongoose')

const connectMongoDB = (url) => {
    return mongoose.connect(url,{
        useNewURLParser: true,
        useUnifiedTopology: true,
    })
}

module.exports = connectMongoDB
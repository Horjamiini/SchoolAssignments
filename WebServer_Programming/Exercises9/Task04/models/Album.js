const mongoose = require('mongoose')
const { Schema } = mongoose

const albumSchema = new Schema({
    artist: {
        type: String,
        required: [true, 'Artist must be provided!']
    },
    title:{
        type: String,
        required: [true, 'Title must be provided!'],
    },
    year: {
        type: Number,
        min: [1900, 'Year cannot be lower than 1900'],
        max: [2023, 'Its 2023 now, album cannot be newer!']

    },
    genre: String
})

const Album = mongoose.model('Album', albumSchema)

module.exports = Album
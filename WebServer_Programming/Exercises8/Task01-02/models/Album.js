const mongoose = require('mongoose')
const { Schema } = mongoose
const albumSchema = new mongoose.Schema({
    artist: {
        type: String,
        required: [true, 'Artist must be provided!'],
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
    genre: String,
    tracks: {
        type: Number,
        min: [1,'Album must have at least 1 track']
    },
    // add tag to determine which user created the album
    createdBy: {
        type: Schema.Types.ObjectId,
        ref: 'User',
        require: true
    }
})
  
const Album = mongoose.model('Album', albumSchema)

module.exports = Album
const mongoose = require('mongoose')
const albumSchema = new mongoose.Schema({
    artist: String,
    title: String,
    year: Number,
    genre: String,
    tracks: Number,
  })
  
const Album = mongoose.model('Album', albumSchema)

module.exports = Album
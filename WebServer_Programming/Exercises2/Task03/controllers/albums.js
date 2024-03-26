const { albums } = require('../data')

const getAlbums = (req, res) => {
    
    const newAlbums = albums.map((album) => {
        const { id, artist, title, year, genre, tracks} = album
        return { id, artist, title, year, genre, tracks}
    })
    res.json(newAlbums)
}

const createAlbum = (req, res) => {
    const { artist, title, year, genre, tracks} = req.body
    if (!artist){
        return res
            .status(400)
            .json({success: false, msg:`Cannot create album without artist`})
    }
    res.status(201).json({success: true, artist: artist, title: title, year: year, genre: genre, tracks: tracks})
}

const updateAlbum = (req, res) => {
    const { id } = req.params
    const { year, genre, tracks } = req.body
    
  const album = albums.find((album) => album.id === Number(id))
  
  if(!album) {
    return res
      .status(404)
      .json({success: false, msg:`No album found with id ${id}`})
  }
  
  const newAlbums = albums.map((album) => {
    if (album.id === Number(id)) {
      album.year = year
      album.genre = genre
      album.tracks = tracks
    }
    return album
  })
  res.status(200).json({success: true, data: newAlbums})
}

const deleteAlbum = (req, res) => {
    const { id } = req.params
    const album = albums.find((album) => album.id == Number(id))
    if (!album) {
      return res
      .status(404)
      .json({success: false, msg:`No album found with id ${id}`})
    }
    const newAlbums = albums.filter(
      (album) => album.id !== Number(id)
    )
    return res.status(200).json({success: true, data: newAlbums})
}

const queryAlbums = (req,res) => {
  console.log(req.query)
  res.status(200)
}

module.exports = {
    getAlbums,
    createAlbum,
    updateAlbum,
    deleteAlbum,
    queryAlbums
}
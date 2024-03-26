const Album = require('../models/Album')

const getAlbums = async (req, res) => {
    try {
        const albums = await Album.find({})
        res.status(200).json({ albums })
    }
    catch (error){
        res.status(500).json({ msg: error })
    }
}

const getOneAlbum = async (req, res) => {
    const { id } = req.params
    try {
        const album = await Album.findById(id)
        res.status(200).json({ album })
    }
    catch (error) {
        res.status(500).json({ msg: error })
    }
}

const createAlbum = async (req, res) => {
    try {
        const albums = await Album.create(req.body)
        res.status(200).json({ albums })
    }
    catch (error) {
        res.status(500).json({ error })
    }
}

const updateAlbum = async (req, res) => {
    const { id } = req.params
    const { year, genre, tracks } = req.body

    try {
        const updatedAlbum = await Album.findByIdAndUpdate(id, {year, genre, tracks} ,{new: true})
        console.log(updatedAlbum)
        res.status(200).json({ updatedAlbum })
    }
    catch (error) {
        res.status(500).json({ error })
    }
}

const deleteAlbum = async (req, res) => {
    const { id } = req.params
    try {
        const album = await Album.findByIdAndDelete(id)
        res.status(200).json({ album })
    }
    catch (error) {
        res.status(500).json({ error })
    }
}

const queryAlbums = (req,res) => {
    console.log(req.query)
    res.status(200)
}

module.exports = {
    getAlbums,
    getOneAlbum,
    createAlbum,
    updateAlbum,
    deleteAlbum,
    queryAlbums
}
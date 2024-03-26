const express = require('express')
const router = express.Router()
const auth = require('../middleware/auth')

const {
    getAlbums,
    getOneAlbum,
    createAlbum,
    updateAlbum,
    deleteAlbum
} = require('../controllers/albums')

router.get('/',getAlbums)
router.get('/:id',getOneAlbum)
router.post('/',auth, createAlbum)
router.put('/:id',updateAlbum)
router.delete('/:id',deleteAlbum)

module.exports = router
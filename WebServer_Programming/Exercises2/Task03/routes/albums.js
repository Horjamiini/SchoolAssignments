const express = require('express')
const router = express.Router()
const auth = require('../middleware/auth')

const {
    getAlbums,
    createAlbum,
    updateAlbum,
    deleteAlbum
} = require('../controllers/albums')

router.get('/',getAlbums)
router.post('/',auth, createAlbum)
router.put('/:id',updateAlbum)
router.delete('/:id',deleteAlbum)

module.exports = router
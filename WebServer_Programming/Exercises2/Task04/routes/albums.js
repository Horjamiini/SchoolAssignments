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
router.post('/', createAlbum)
router.put('/:id',updateAlbum)
router.delete('/:id',auth,deleteAlbum)

module.exports = router
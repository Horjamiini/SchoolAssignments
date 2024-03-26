const express = require('express')
const router = express.Router()
const auth = require('../middleware/auth')

const {
    getOneAlbum,
    createAlbum,
    updateAlbum,
    deleteAlbum,
    getAllAlbums
} = require('../controllers/albums')

router.get('/:id',getOneAlbum)
router.post('/',auth, createAlbum)
router.put('/:id',updateAlbum)
router.delete('/:id',deleteAlbum)
router.route('/').get(getAllAlbums)

module.exports = router
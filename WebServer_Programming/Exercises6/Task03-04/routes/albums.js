const express = require('express')
const router = express.Router()
const authUser = require('../middleware/auth')

const {
    getOneAlbum,
    createAlbum,
    updateAlbum,
    deleteAlbum,
    getAllAlbums
} = require('../controllers/albums')

router.get('/',getAllAlbums)
router.get('/:id',getOneAlbum)
router.post('/',authUser, createAlbum)
router.put('/:id',authUser,updateAlbum)
router.delete('/:id',authUser,deleteAlbum)


module.exports = router
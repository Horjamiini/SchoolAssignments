let albumsAtStart = require('../data/albums')
const Album = require('../models/Album')
const _ = require('lodash')


class AlbumAPI {
    constructor() {
    }
    async initialize(config){
    }
    async getAlbums(args){
        const albums = await Album.find({})
        return albums
    }
    async getAlbumById(_id) {
        const album = await Album.findById({_id})
        return album
    }
    async deleteAlbum(_id) {
        const album = await Album.findByIdAndDelete({_id})
        return album
    }
}

module.exports = AlbumAPI
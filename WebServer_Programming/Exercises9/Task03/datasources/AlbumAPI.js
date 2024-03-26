let albums = require('../data/albums')
const _ = require('lodash')


class AlbumAPI {
    constructor() {
    }
    initialize(config){
    }
    getAlbums(args){
        return albums
    }
    getAlbumById(_id) {
        const album = _.filter(albums, { _id })
        return album[0]
    }
    deleteAlbum(_id) {
        const album = _.filter(albums, (album) => album._id === _id)
        albums = _.filter(albums, (album) => album._id !== _id)
        return album[0]
    }
}

module.exports = AlbumAPI
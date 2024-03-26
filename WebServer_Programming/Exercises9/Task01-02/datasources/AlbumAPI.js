const albums = require('../data/albums')
const _ = require('lodash')

class AlbumAPI {
    constructor() {
    }
    initialize(config){
    }
    getAlbums(args){
        return _.filter(albums, args)
    }
    getAlbumById(id) {
        const album = _.filter(albums, { id })
        return album[0]
    }
}

module.exports = AlbumAPI
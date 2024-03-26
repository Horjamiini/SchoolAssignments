module.exports = {
    albums: ( _parent, args, { dataSources }) => {
        return dataSources.albumApi.getAlbums(args)
    },
    albumsById: ( _parent, { _id }, { dataSources }) => {
        return dataSources.albumApi.getAlbumById(_id)
    } 
}
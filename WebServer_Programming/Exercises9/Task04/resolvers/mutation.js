module.exports = {
    deleteAlbum: (_parent, { _id }, { dataSources }) => {
    return dataSources.albumApi.deleteAlbum(_id)
    }
}
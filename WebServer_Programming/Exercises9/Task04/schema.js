const { ApolloServer } = require('@apollo/server')

module.exports = `#graphql
type Album {
    _id: ID!,
    artist: String!,
    title: String!,
    year: Int,
    genre: String
}
type Query {
    albums: [Album],
    albumsById(_id:ID): Album,
}
type Mutation {
    deleteAlbum(_id:ID): Album
}
`
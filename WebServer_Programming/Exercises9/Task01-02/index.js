const { ApolloServer } = require('@apollo/server')
const  { startStandaloneServer } = require('@apollo/server/standalone')
const AlbumAPI = require('./datasources/AlbumAPI')

const typeDefs = `#graphql
    type Album {
        _id: ID!,
        artist: String!,
        title: String!,
        year: Int,
        genre: String
    }
    type Owner {
        _id: ID!
        username: String
        name: String
        albums: [Album]
    }
    type Query {
        albums(
            _id: ID,
            artist: String,
            title: String,
            year: Int,
            genre: String
        ) : [Album],

        albumsById(_id:ID): Album,
        owners: [Owner],
        ownerById(_id:ID): Owner

    }
`

const resolvers = {
    Query: {
        albums: ( _parent, args, { dataSources }) => {
            return dataSources.albumApi.getAlbums(args)
        },
        albumsById: ( _parent, { _id }, { dataSources }) => {
            return dataSources.albumApi.getAlbumById(_id)
        }    
    }
}

const server = new ApolloServer({
    typeDefs,
    resolvers,
})

const start = async () => {
    const { url } = await startStandaloneServer(server, {
        context: async () => {
            return {
                dataSources: {
                    albumApi: new AlbumAPI(),
                }
            }
        }
    });
    console.log(`💿 Server ready at ${url}`)
}
start()
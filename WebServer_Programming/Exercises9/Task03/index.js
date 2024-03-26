const { ApolloServer, gql } = require('@apollo/server')
const  { startStandaloneServer } = require('@apollo/server/standalone')
const AlbumAPI = require('./datasources/AlbumAPI')

const typeDefs = require('./schema')

const resolvers = require('./resolvers')

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
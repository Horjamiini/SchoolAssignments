require('dotenv').config()
const { ApolloServer } = require('@apollo/server')
const { startStandaloneServer } = require('@apollo/server/standalone')
const AlbumAPI = require('./datasources/AlbumAPI')
const mongoose = require('mongoose')

const typeDefs = require('./schema')

  
const resolvers = require('./resolvers')

const server = new ApolloServer({
    typeDefs,
    resolvers,
})

const MONGODB_URI = process.env.CONN_STRING

mongoose.connect(MONGODB_URI, {
    useNewUrlParser: true,
    useUnifiedTopology: true,
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
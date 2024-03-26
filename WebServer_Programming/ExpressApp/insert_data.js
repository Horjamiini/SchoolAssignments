require('dotenv').config()

const connectDB = require('./db/mongodb')
const Album = require('./models/Album')

const jsonAlbums = require('./jsonAlbums.json')

const insertData = async () => {
    try {
        await connectDB(process.env.CONN_STRING)
        // Remove existing data
        await Album.deleteMany()
        // Create the data from json file
        await Album.create(jsonAlbums)
        console.log('Success!!!!')
        process.exit(0)
    } catch (error) {
        console.log(error)
        process.exit(1)
    }
}
  
insertData()
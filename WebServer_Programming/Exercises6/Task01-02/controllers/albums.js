// eslint-disable-next-line no-unused-vars
const { createAPIError, APIError } = require('../errors/apierror')
const Album = require('../models/Album')

const getAllAlbums = async (req, res) => {
    const { artist, title, genre, numericFilters, fields, sort } = req.query
    const queryObject = {}
    
    if (artist) queryObject.artist = { $regex: artist, $options: 'si'}
    if (title) queryObject.title = { $regex: title, $options: 'si'}
    if (genre) queryObject.genre = { $regex: genre, $options: 'i' }
    if (numericFilters) {
        const operatorMap = {
            '>' : '$gt',
            '>=' : '$gte',
            '=' : '$eq',
            '<' : '$lt',
            '<=' : '$lte'
        }
    
        const regEx = /\b(>|>=|=|<|<=)\b/g
        let filters = numericFilters.replace(regEx, (match) => `-${operatorMap[match]}-`)
        console.log(filters)
        const options = ['year','tracks']
        filters = filters.split(',').forEach((item) => {
            const [field,operator,value] = item.split('-')
            if(options.includes(field)) {
                queryObject[field] = {[operator] : Number(value)}
            }
        })
    }

    console.log(queryObject)
    let result = Album.find(queryObject)

    if (fields) {
        const fieldlist = fields.split(',').join(' ')
        result = result.select(fieldlist)  
    }
    
    if (sort) {
        const sortList = sort.split(',').join(' ')
        result = result.sort(sortList)
    }
    else {
        result = result.sort('year')
    }

    const albums = await result
    res.status(200).json({ albums, nbHibits: albums.length })

}

const getOneAlbum = async (req, res) => {
    const { id } = req.params
    const album = await Album.findById(id)
    console.log(album)
    if (!album) {
        throw new APIError('couldnt get album', 400)
    }
    else {
        res.status(200).json({ album })
    }
}

const createAlbum = async (req, res) => {

    const albums = await Album.create(req.body)
    res.status(200).json({ albums })

}

const updateAlbum = async (req, res) => {
    const { id } = req.params
    const { year, genre, tracks } = req.body

    const updatedAlbum = await Album.findByIdAndUpdate(id, {year, genre, tracks} ,{new: true})
    console.log(updatedAlbum)
    res.status(200).json({ updatedAlbum })

}

const deleteAlbum = async (req, res) => {
    const { id } = req.params

    const album = await Album.findByIdAndDelete(id)
    res.status(200).json({ album })

}

const queryAlbums = (req,res) => {
    console.log(req.query)
    res.status(200)
}

module.exports = {
    getOneAlbum,
    createAlbum,
    updateAlbum,
    deleteAlbum,
    queryAlbums,
    getAllAlbums
}
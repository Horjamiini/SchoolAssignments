// eslint-disable-next-line no-unused-vars
const { APIError } = require('../errors/apierror')
const { BadRequestError, NotFoundError, UnauthorizedError} = require('../errors')
const { StatusCodes } = require('http-status-codes')
const Album = require('../models/Album')

const getAllAlbums = async (req, res) => {
    const { artist, title, genre, numericFilters, fields, sort} = req.query
    const queryObject = {}

    if (!req.user) {
        return res.redirect('/login')
    }

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

    let albums = await result
    
    res.status(200).json({ albums, nbHibits: albums.length })

}

const getOneAlbum = async (req, res) => {
    
    if (!req.user) {
        return res.redirect('/login')
    }
    const { id } = req.params
    const album = await Album.findById(id)
    console.log(album)
    if (!album) {
        throw new NotFoundError('No album found')
    }
    return res.status(StatusCodes.OK).json({ album })
}

const createAlbum = async (req, res) => {
    const { artist, title, year, genre, tracks } = req.body
    const createdBy = req.user.id


    if (!artist || !title) {
        throw new BadRequestError('Artist or title missing')
    }
    const album = await Album.create({
        artist,
        title,
        year,
        genre,
        tracks,
        createdBy
    })
    res.status(200).json({ album })

}

const updateAlbum = async (req, res) => {
    const { id } = req.params
    const { title, year, genre, tracks } = req.body
    const album = await Album.findById(id)
    if (!album) {
        throw new NotFoundError('Album not found')
    }
    if (req.user.id !== album.createdBy.toString() && req.user.role !== 'admin'){
        throw new UnauthorizedError('Not authorized to update this album')
    }
    const updatedAlbum = await Album.findByIdAndUpdate(id, {title, year, genre, tracks} ,{new: true})
    res.status(200).json({ updatedAlbum })

}

const deleteAlbum = async (req, res) => {
    const { id } = req.params
    const album = await Album.findById(id)
    if (!album) {
        throw new NotFoundError('Album not found')
    }
    if (req.user.id !== album.createdBy.toString() && req.user.role !== 'admin'){
        throw new UnauthorizedError('Not authorized to delete this album')
    }
    await Album.findByIdAndDelete(id)
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
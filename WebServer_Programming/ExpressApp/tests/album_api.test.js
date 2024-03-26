const mongoose = require('mongoose')
const supertest = require('supertest')
const app = require('../App')
const Album = require('../models/Album')
const testAlbums = require('./jsonAlbums.json')

const api = supertest(app)


beforeEach(async () => {
    await Album.deleteMany({})
    await Album.create(testAlbums)
})

test('Albums returned as json', async () => {
    await api
        .get('/api/albums')
        .expect(200)
        .expect('Content-Type', /application\/json/)
})

test('Album amount is same as created ones', async () => {
    const resp = await api.get('/api/albums')
    expect(resp.body.albums).toHaveLength(testAlbums.length)
})

test('New album can be created', async () => {
    const newAlbum = {
        artist: 'Ex-Tuuttiz',
        title: 'Kaikki ketkä diggaa...',
        year: 2020,
        genre: 'Rap',
        tracks: 13,
    }
    await api
        .post('/api/albums')
        .send(newAlbum)
        .expect(201)
        .expect('Content-Type', /application\/json/)
    const response = await api.get('/api/albums')
    expect(response.body.albums).toHaveLength(testAlbums.length + 1)  
})

test('Album can be deleted', async () => {
    const albumsAtStart = await api.get('/api/albums')
    const albumToDelete = albumsAtStart.body.albums[0]
    console.log(albumToDelete._id)
    await api
        .delete(`/api/albums/${albumToDelete._id}`)
        .expect(200)
        .expect('Content-Type', /application\/json/)
    const response = await api.get('/api/albums')
    expect(response.body.albums).toHaveLength(testAlbums.length - 1)
})

afterAll( async() => {
    mongoose.connection.close()
})
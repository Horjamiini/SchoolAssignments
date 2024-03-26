require('dotenv').config()
const express = require('express')
const app = express()
require('express-async-errors')
const { PORT } = process.env

const sequelize = require('./db/postgres')

const users = require('./routes/users')
const vehicles = require('./routes/vehicles')
const errorHandler = require('./middleware/errorhandler')

// static assets
app.use(express.static('./public'))
// parse form data
app.use(express.urlencoded({ extended: false }))
// parse json
app.use(express.json())

app.use('/api/users',users)
app.use('/api/vehicles', vehicles)

app.use(errorHandler)

const eraseDatabaseOnSync = process.env.ERASE || false
// const eraseDatabaseOnSync = true

sequelize.sync({ force: eraseDatabaseOnSync }).then(() => {
    app.listen(PORT, () => {
        console.log(`Server is listening on port ${PORT}...`) 
    })
})


const express = require('express')
const app = express()
const { vehicles } = require('./data')

app.use(express.json())

app.get('/', (req, res) => {
  res.send('<h1>API front</h1><a href="/api/vehicles">vehicles</a>')
})
app.get('/api/vehicles', (req, res) => {
  const newVehicles = vehicles.map((vehicle) => {
    const { id, make, model } = vehicle
    return { id, make, model }
  })
  res.json(newVehicles)
})


app.get('/api/vehicles/:vehicleID', (req, res) => {
    //console.log(req)
  console.log(req.params)
  const { vehicleID } = req.params

  const singleVehicle = vehicles.find(
    (vehicle) => vehicle.id === Number(vehicleID)
  )
  if (!singleVehicle) {
    return res.status(404).send('Vehicle not found!')
  }
  return res.json(singleVehicle)
})

app.get('/api/query', (req, res) => {
  console.log(req.query)
  // looking for the keys search and limit in req.query
  const { search, limit } = req.query
  // copying the array and placing it in a let variable
  let sortedVehicles = [...vehicles]

  if (search) {
    sortedVehicles = sortedVehicles.filter((vehicle) => {
      return vehicle.make.startsWith(search)
    })
  }
  if (limit) {
    sortedVehicles = sortedVehicles.slice(0, Number(limit))
  }
  if (sortedVehicles.length < 1) {
    return res.status(200).json({ success: true, data: [] })
  }
  res.status(200).json(sortedVehicles)
})

app.post('/api/vehicles', (req, res) => {
  console.log(req.body)
  const { make } = req.body
  if (!make) {
    return res
      .status(400)
      .json({ success: false, msg: 'No make value provided' })
  }
  res.status(201).json({ success: true, vehicle: make })
})

app.put('/api/vehicles/:id', (req, res) => {
  const { id } = req.params
  const { make } = req.body

  const vehicle = vehicles.find((vehicle) => vehicle.id === Number(id))
  
  if(!vehicle) {
    return res
      .status(404)
      .json({success: false, msg:`No vehicle found with id ${id}`})
  }
  
  const newVehicles = vehicles.map((vehicle) => {
    if (vehicle.id === Number(id)) {
      vehicle.make = make
    }
    return vehicle
  })
  res.status(200).json({success: true, data: newVehicles})
})

app.delete('/api/vehicles/:id', (req, res) => {
  const { id } = req.params
  const vehicle = vehicles.find((vehicle) => vehicle.id == Number(id))
  if (!vehicle) {
    return res
    .status(404)
    .json({success: false, msg:`No vehicle found with id ${id}`})
  }
  const newVehicles = vehicles.filter(
    (vehicle) => vehicle.id !== Number(id)
  )
  return res.status(200).json({success: true, data: newVehicles})
})



const PORT = 5001
app.listen(PORT, ()=> {
  console.log(`server listening on port ${PORT}...`)
})

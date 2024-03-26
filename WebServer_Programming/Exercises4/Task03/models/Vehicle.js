const mongoose = require('mongoose')

const vehicleSchema = new mongoose.Schema({
  make: {
    type: String,
    required: true,
    maxLength: 10,
  },
  model: String,
  type: {
    type: String,
    required: true
  },
  license_plate: {
    type: String,
    validate: {
      validator: function(v) {
        return /^[A-Z]{3}-[0-9]{3}$/.test(v)
      },
      message: props => `${props.value} in not valid license plate!`
    },
    required: [true, 'License plate required!']
  }
})



module.exports = mongoose.model('Vehicle', vehicleSchema)

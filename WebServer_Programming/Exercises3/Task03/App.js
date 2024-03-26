require('dotenv').config()
const mongoose = require('mongoose')

mongoose.connect(process.env.CONN_STRING)

const personSchema = new mongoose.Schema({
    firstname: String,
    lastname: String,
})

const Person = mongoose.model('Person',personSchema,'people')


if (process.argv[2] == null && process.argv[3] == null){
    Person.find({}).then(result => {
        result.forEach(p => {
            console.log(p)
        })
        mongoose.connection.close()
    })
}
else if ((process.argv[2] == null && process.argv[3]) || (process.argv[2] && process.argv[3] == null)){
    console.log("Invalid arguments!")
    mongoose.connection.close()
}
else {
    const person = new Person({
        firstname: process.argv[2],
        lastname: process.argv[3],
    })

    person.save().then(result => {
        console.log('Person saved!')
        mongoose.connection.close()
    })
}
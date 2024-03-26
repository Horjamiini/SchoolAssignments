// eslint-disable-next-line no-unused-vars
const { ApolloServer } = require('@apollo/server')

module.exports = `#graphql
type Vehicle {
    _id: ID!,
    make: String!,
    model: String,
    type: String,
    licence_plate: String,
    comissioned: Boolean!,
    userId: ID!
}
type User {
    _id: ID!,
    username: String!,
    name: String!,
    vehicles: [Vehicle]
}
type Query {
    vehicles: [Vehicle],
    vehicleById(_id:ID): Vehicle,
    users: [User],
    userById(_id:ID): User 
}
type Mutation {
    modifyVehicle(_id:ID): Vehicle,
    deleteVehicle(_id:ID): Vehicle
}
`
module.exports = {
    vehicles: async (_parent, args, { dataSources }) => {
        return dataSources.vehicleApi.getVehicles()
    },
    vehicleById: async (_parent, { _id }, { dataSources }) => {
        return dataSources.vehicleApi.getVehicleById(_id)
    },
    users: async (_parent, args, { dataSources }) => {
        return dataSources.userApi.getUsers(args)
    },
    userById: async (_parent, { _id }, { dataSources }) => {
        return dataSources.userApi.getUserById(_id)
    }
}
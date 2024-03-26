module.exports = {
    modifyVehicle: (_parent, { _id }, { dataSources }) => {
        return dataSources.vehicleApi.modifyVehicle(_id)
    },
    deleteVehicle: (_parent, { _id }, { dataSources }) => {
        return dataSources.vehicleApi.deleteVehicle(_id)
    }
}
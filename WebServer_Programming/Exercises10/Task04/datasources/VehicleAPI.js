const { RESTDataSource } = require('@apollo/datasource-rest')

class VehicleAPI extends RESTDataSource {
 
    baseURL = 'http://localhost:5001/'

    async getVehicles() {
        const vehicles = await this.get('api/vehicles')
        console.log(vehicles.data)
        return vehicles.data
    }
    async getVehicleById(_id) {
        const vehicle = await this.get(`api/vehicles/${_id}`)
        return vehicle
    }
    async modifyVehicle(_id) {
        const vehicle = await this.put(`api/vehicles/${_id}`)
        return vehicle
    }
    async deleteVehicle(_id) {
        const vehicle = await this.delete(`api/vehicles/${_id}`)
        return vehicle
    }
}

module.exports = VehicleAPI
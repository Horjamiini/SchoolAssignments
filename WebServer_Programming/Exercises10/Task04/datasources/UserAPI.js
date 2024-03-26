const { RESTDataSource } = require('@apollo/datasource-rest')

class UserAPI extends RESTDataSource {
    constructor() {
        super()
        this.baseURL = 'http://localhost:5001/'
    }
    async getUsers() {
        const users = await this.get('api/users')
        return users.data
    }
    async getUserById(_id) {
        const user = await this.get(`api/users/${_id}`)
        return user
    }
}

module.exports = UserAPI
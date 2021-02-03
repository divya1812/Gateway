module.exports = {
    dbConnection: {
        user: "postgres",
        password: "12345",
        host: "localhost",
        database: "MyTestDb",
        port: 5432
    },
    server: {
        PORT: 3000,
    },
    jwtConfig: {
        algorithm: "HS256",
        secretKey: "Test@12345",
    },

};
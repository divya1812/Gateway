module.exports = {
    dbConnection: {
        user: 'postgres',
        host: 'localhost',
        database: 'Car Details',
        password: 'POST1812@gresql',
        port: 5432,
    },
    server: {
        PORT: 3000,
    },
    jwtConfig: {
        algorithm: "HS256",
        secretKey: "Test@12345",
    },

};
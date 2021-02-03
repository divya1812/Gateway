var jwt = require('jsonwebtoken');
var HttpStatusCode = require("http-status-codes");
var settings = require('../config.js');

generateToken = function (payload) {
    var userInfo = {
        Id: payload.id,
        Email: payload.email,
        Username: payload.username
    };
    var token = jwt.sign(userInfo, settings.jwtConfig.secretKey);
    return {
        status: HttpStatusCode.StatusCodes.OK,
        data: 'Bearer ' + token
    };
}

module.exports = generateToken;
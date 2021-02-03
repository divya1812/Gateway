var StatusCode = require('http-status-codes');
var dbConnection = require('../../../utilities/postgresql-connection.js');
var settings = require('../../../config.js');
var validate = require('validator');
var HttpStatusCode = require("http-status-codes");

exports.getUserById = function (req, res) {
    var entityData = {
        Id: req.params.id
    };

    function validateFields(req, res) {
        return new Promise(function (resolve, reject) {
            var isUserIdEmpty = validate.isEmpty(entityData.Id);
            if (isUserIdEmpty) {
                return resolve({
                    status: HttpStatusCode.StatusCodes.BAD_REQUEST,
                    result: req.i18n.__('UserIdRequired')
                });
                //return res.status(400).send({ result: req.i18n.__('UserIdRequired') });
            }
            
            return resolve({
                status: HttpStatusCode.StatusCodes.OK,
                data: entityData
            });
        });
    }

    function getUserById(req, entityData) {
        return new Promise(function (resolve, reject) {
            const sqlQuery = 'SELECT * FROM users WHERE id = ' + entityData.Id;
            dbConnection.getResult(sqlQuery).then(function (response) {
                if (response.data.length > 0) {
                    return resolve({
                        status: HttpStatusCode.StatusCodes.OK,
                        data: response,
                        message: 'Record listed successfully!!!'
                    });
                } else {
                    return resolve({
                        status: HttpStatusCode.StatusCodes.OK,
                        data: [],
                        message: 'No record found!!!'
                    });
                }                
            })
            .catch(function (error) {
                res.status(error.status).json({
                    data: error.data
                });
            });
        });
    }

    validateFields(req, res).then(function (response) {
        getUserById(req, response.data).then(function (response) {
            res.status(response.status).json({
                data: response.data.data,
                message: response.message
            });
        })
        .catch(function (error) {
            res.status(error.status).json({
                data: error.data
            });
        });
    })
    .catch(function (error) {
        res.status(error.status).json({
            data: error.data
        });
    });
    
}

var HttpStatusCode = require("http-status-codes");
var jwtDecode = require("jwt-decode");
var settings = require("../config.js");
var dbConnection = require('./postgresql-connection.js');

function verifyUserValidity(UserId, Email, UserName) {
  return new Promise(function (resolve, reject) {

    const sqlQuery = "SELECT * FROM users WHERE id = '" + UserId + "' AND email = '" + Email + "' ";
    dbConnection.getResult(sqlQuery).then(function (response) {
        if (response.data.length > 0) {
            return resolve({
              status: HttpStatusCode.StatusCodes.OK,
            });                   
        } else {
            return resolve({
                status: HttpStatusCode.StatusCodes.OK,
                data: [],
                message: 'Invalid User!!!'
            });
        }                
    })
    .catch(function (error) {
        res.status(HttpStatusCode.StatusCodes.BAD_REQUEST).json({
            data: error.data
        });
    });

  });
}

ensureToken = function (req, res, next) {
  var bearerHeader = req.headers["authorization"];
  if (typeof bearerHeader !== "undefined") {
    var bearer = bearerHeader.split(" ");
    var bearerToken = bearer[1];
    req.token = bearerToken;
    req.decodedToken = jwtDecode(bearerToken);
    if (req.decodedToken.Id && req.decodedToken.Email && req.decodedToken.Id > 0 && req.decodedToken.Email != '') {
      verifyUserValidity(
        req.decodedToken.Id,
        req.decodedToken.Email,
        req.decodedToken.UserName
      )
        .then(function (response) {
          if (response.status == HttpStatusCode.StatusCodes.FORBIDDEN) {
            res.sendStatus(HttpStatusCode.StatusCodes.FORBIDDEN);
          } else {
            next();
          }
        })
        .catch(function (error) {
          var string = JSON.stringify(error);
          var objectValue = JSON.parse(string);
          var status = objectValue.status;
          if (status == HttpStatusCode.StatusCodes.FORBIDDEN) {
            res.status(HttpStatusCode.StatusCodes.FORBIDDEN).json({
              data: req.i18n.__("SystemError"),
            });
          } else {
            res.status(HttpStatusCode.StatusCodes.UNAUTHORIZED).json({
              data: req.i18n.__("SystemError"),
            });
          }
        });
    } else { 
      res.sendStatus(HttpStatusCode.StatusCodes.FORBIDDEN);  
    }
  } else {
    res.sendStatus(HttpStatusCode.StatusCodes.FORBIDDEN);
  }
};

module.exports = ensureToken;

const { Pool } = require('pg')
var HttpStatusCode = require("http-status-codes");

var settings = require("../config.js");

async function getResult(sqlQuery) {
  var res = await getResultArray(sqlQuery) // a is 5
  return res;
}

async function getResultArray(sqlQuery){ 
  return new Promise(function (resolve, reject) {
      pool = new Pool({
      user: settings.dbConnection.user,
      host: settings.dbConnection.host,
      database: settings.dbConnection.database,
      password: settings.dbConnection.password,
      port: settings.dbConnection.port,
    });

    return pool.query(sqlQuery, (err, result) => { 
      if (result.rows.length > 0) {
        return resolve({
          status: HttpStatusCode.StatusCodes.OK,
          data: result.rows
        });
      } else { 
        return resolve({
          status: HttpStatusCode.StatusCodes.OK,
          data: []
        });
      }        
    })

  });
  
}

module.exports = {
  getResult
}
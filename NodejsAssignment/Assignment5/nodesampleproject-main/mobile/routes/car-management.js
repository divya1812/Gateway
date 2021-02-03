var express = require("express");
var router = express.Router({
  caseSensitive: true,
});
var ensureToken = require('../../utilities/ensure-token.js');



/**
 *  Get All Cars
 */
var getAllCarsCtrl = require('../controllers/car-management/get-all-cars.js');
router.get("/all", ensureToken, function (req, res) {
  return getAllCarsCtrl.getAllCars(req, res);
});

/**
 *  Get Car By Id
 */
var getCarByIdCtrl = require("../controllers/car-management/get-car-by-id.js");
router.get("/:id", ensureToken, function (req, res) {
  return getCarByIdCtrl.getCarById(req, res);
});

module.exports = router;
var express = require("express");
var router = express.Router({
  caseSensitive: true,
});
var ensureToken = require('../../utilities/ensure-token.js');


/**
 *  User Login
 */
var userLoginCtrl = require('../controllers/user-management/login.js');
router.post("/login", function (req, res) {
  return userLoginCtrl.userLogin(req, res);
});

/**
 *  Get All Users
 */
var getAllUsersCtrl = require('../controllers/user-management/get-all-users.js');
router.get("/all", ensureToken, function (req, res) {
  return getAllUsersCtrl.getAllUsers(req, res);
});

/**
 *  Get User By Id
 */
var getUserByIdCtrl = require("../controllers/user-management/get-user-by-id.js");
router.get("/:id", ensureToken, function (req, res) {
  return getUserByIdCtrl.getUserById(req, res);
});

module.exports = router;
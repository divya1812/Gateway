var createError = require('http-errors');
var express = require('express');
var path = require('path');
var cookieParser = require('cookie-parser');
var logger = require('morgan');
var HttpStatusCode = require("http-status-codes");
var i18n = require('i18n-2');
var lcid = require('lcid');

var indexCMSRouter = require('./routes/index');
var userCMSRouter = require('./routes/users');

var apiMobileUserManagementRouter = require('./mobile/routes/user-management');
var apiMobileContactManagementRouter = require('./mobile/routes/contact-management');
//var usersRouter = require('./routes/users');
//var settings = require('./config.js');

var app = express();

// view engine setup
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'jade');

app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

/**
 *  Localization +
 *  Ref: https://www.npmjs.com/package/i18n-2
 *  Attach the i18n property to the express request object
 *  And attach helper methods for use in templates
 */
i18n.expressBind(app, {
    locales: ['en-us', 'sv-se','da-dk'],
    extension: ".json",
    defaultLocale: 'en-us'
});

/**
 *  This is how you'd set a locale from req.cookies.
 *  Don't forget to set the cookie either on the client or in your Express app. 
 */
/* https://www.robvanderwoude.com/languagecodes.php */
/* http://www.lingoes.net/en/translator/langcode.htm */
app.use(function(req, res, next) {
    var lang = 1053;
    var file = '';
    if (req.headers['accept-language'] == 1033) {
        lang = 1033;
    }else if (req.headers['accept-language'] == 1030) {
        lang = 1030;
    }
    file = lcid.from(lang);
    file = file.replace('_', '-').toLowerCase();
    req.i18n.setLocale(file);
    next();
});

// CMS/Admin API's
app.use('/', indexCMSRouter);
app.use('/user', userCMSRouter);


// Mobile API's
app.use('/api/user/', apiMobileUserManagementRouter);

// catch 404 and forward to error handler
app.use(function(req, res, next) {
  next(createError(HttpStatusCode.StatusCodes.NOT_FOUND));
});

// error handler
app.use(function(err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get('env') === 'development' ? err : {};

  // render the error page
  res.status(err.status || HttpStatusCode.StatusCodes.INTERNAL_SERVER_ERROR);
  res.render('error');
});

module.exports = app;
const express = require('express')
const bodyParser = require('body-parser')
const db = require('./queries')

const app = express()
const port = 3000

app.use(bodyParser.json())
app.use(
  bodyParser.urlencoded({
    extended: true,
  })
)

var multer  = require('multer');
var storage = multer.diskStorage({
    destination: (req, file, cb) => {
      cb(null, './upload/car_image');
    },
    filename: (req, file, cb) => {
      //console.log(file);
      var filetype = '';
      if(file.mimetype === 'image/gif') {
        filetype = 'gif';
      }
      if(file.mimetype === 'image/png') {
        filetype = 'png';
      }
      if(file.mimetype === 'image/jpeg') {
        filetype = 'jpg';
      }
      cb(null, 'image-' + Date.now() + '.' + filetype);
    }
});
var upload = multer({ storage: storage });

app.post('/upload', upload.single('profilepicture'), function (req, res, next) {
  const carid = req.body.carid;
  const imagename = 'http://localhost:3000/upload/car_image/'+req.file.filename;
  const createddate = new Date();

  if (!req.file) {
    res.status(500);
    return next(err);
  } 
  db.uploadCarImage(carid,imagename,createddate,res);
})


app.get('/', db.getCarswithImage)
app.get('/cars', db.getCars)
app.get('/cars/:id', db.getCarById)
app.get('/carimages/:id', db.getCarswithImageById)
app.post('/cars', db.createCar)
app.put('/cars/:id', db.updateCar)
app.delete('/cars/:id', db.deleteCar)

app.listen(port, () => {
  console.log(`App running on port ${port}.`)
})
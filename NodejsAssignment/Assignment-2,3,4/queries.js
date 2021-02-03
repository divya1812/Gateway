const Pool = require('pg').Pool
const pool = new Pool({
  user: 'postgres',
  host: 'localhost',
  database: 'Car Details',
  password: 'POST1812@gresql',
  port: 5432,
})


const getCars = (request, response) => {
  pool.query('SELECT car.id ,car.carname ,make.makename ,model.modelname FROM car INNER JOIN make ON car.makeid = make.id INNER JOIN model ON car.modelid = model.id', (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}

const getCarswithImage = (request, response) => {
  pool.query('SELECT car.id ,car.carname ,make.makename ,model.modelname ,array_agg(carimages.imagename) as "Image" FROM car INNER JOIN make ON car.makeid = make.id INNER JOIN model ON car.modelid = model.id INNER JOIN carimages ON car.id = carimages.carid GROUP BY car.id ,make.makename,model.modelname', (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}

const getCarswithImageById = (request, response) => {
  const id = parseInt(request.params.id)
  pool.query('SELECT car.id ,car.carname ,make.makename ,model.modelname ,array_agg(carimages.imagename) as "Image" FROM car INNER JOIN make ON car.makeid = make.id INNER JOIN model ON car.modelid = model.id INNER JOIN carimages ON car.id = carimages.carid where car.id = $1 GROUP BY car.id ,make.makename,model.modelname;', [id],(error, results) => {
    if (error) {
      throw error
    }
    if(results.rowCount===0){
      response.status(404).json({Message: "Data doesnt exist"})
    }
    else{
      response.status(200).json(results.rows)
    }
  })
}


const getCarById = (request, response) => {
  const id = parseInt(request.params.id)

  pool.query('SELECT car.id ,car.carname ,make.makename ,model.modelname FROM car INNER JOIN make ON car.makeid = make.id INNER JOIN model ON car.modelid = model.id where car.id = $1;', [id], (error, results) => {
    if (error) {
      throw error
    }
    var notExist = results.rowCount;
    if(notExist === 0){
      response.status(200).json("ID Not Exist")
    }
    else{
    response.status(200).json(results.rows)
    }
  })
}

const uploadCarImage = (carid,imagename,createddate,res) => {

  pool.query('INSERT INTO public.carimages (carid, imagename, createdat) VALUES($1, $2, $3);', [carid,imagename,createddate], (error, results) => {
    if (error) {
      throw error
    }
    res.status(201).send(`Image added for Car id ${carid}`)
  })
}



const createCar = (request, response) => {
  const { name, makename , modelname } = request.body
  var namerowcount = 0;
  var modelrowcount = 0;
  var makerowcount = 0;
  var modelid = 0; 
  var makeid = 0;
  pool.query('SELECT * FROM public.car where carname= $1', [name], (error, results) => {
    if (error) {
      throw error
    }
    namerowcount = results.rowCount;
    if(namerowcount > 0){
      response.status(409).send(`Car already exist!!`)
    }
    else{
      pool.query('SELECT id FROM public.model where modelname = $1;', [modelname], (error, results) => {
        if (error) {
          throw error
        }
        modelrowcount = results.rowCount;
        if(modelrowcount > 0){
          var temp = results.rows
          modelid = temp[0]['id'];
        }
        else{
          pool.query('INSERT INTO public.model (modelname) VALUES($1) RETURNING id;', [modelname], (error, results) => {
            if (error) {
              throw error
            }
            modelid = results.rows[0].id;
          })
        }
      })
      pool.query('SELECT id, makename FROM public.make where makename = $1;', [makename], (error, results) => {
        if (error) {
          throw error
        }
        makerowcount = results.rowCount;
        if(makerowcount > 0){
          var temp = results.rows
          makeid = temp[0]['id'];
        }
        else{
          pool.query('INSERT INTO public.make (makename) VALUES($1) RETURNING id;', [makename], (error, results) => {
            if (error) {
              throw error
            }
            makeid = results.rows[0].id;
          })
        }
        if(modelid != 0 && makeid !=0){
          pool.query('INSERT INTO public.car (carname, makeid, modelid) VALUES ($1, $2, $3) RETURNING id;', [name,makeid,modelid], (error, results) => {
            if (error) {
              throw error
            }
            var carid = results.rows[0].id;
            response.status(201).send(`Car added with ID: ${carid}`)
          })
        }
      })
    }
  })
  
  
}

const updateCar = (request, response) => {
  const id = parseInt(request.params.id)
  const { name, makename , modelname } = request.body
  var namerowcount = 0;
  var modelrowcount = 0;
  var makerowcount = 0;
  var modelid = 0; 
  var makeid = 0;
  pool.query('SELECT * FROM public.car where carname= $1', [name], (error, results) => {
    if (error) {
      throw error
    }
    namerowcount = results.rowCount;
    if(namerowcount > 0){
      response.status(409).send(`Car already exist!!`)
    }
    else{
      pool.query('SELECT id FROM public.model where modelname = $1;', [modelname], (error, results) => {
        if (error) {
          throw error
        }
        modelrowcount = results.rowCount;
        if(modelrowcount > 0){
          var temp = results.rows
          modelid = temp[0]['id'];
          console.log(modelid)
        }
        else{
          pool.query('INSERT INTO public.model (modelname) VALUES($1) RETURNING id;', [modelname], (error, results) => {
            if (error) {
              throw error
            }
            modelid = results.rows[0].id;
            console.log(modelid)
          })
        }
      })
      pool.query('SELECT id, makename FROM public.make where makename = $1;', [makename], (error, results) => {
        if (error) {
          throw error
        }
        makerowcount = results.rowCount;
        if(makerowcount > 0){
          var temp = results.rows
          makeid = temp[0]['id'];
          console.log(modelid)
        }
        else{
          pool.query('INSERT INTO public.make (makename) VALUES($1) RETURNING id;', [makename], (error, results) => {
            if (error) {
              throw error
            }
            makeid = results.rows[0].id;
            console.log(makeid);
          })
        }
        if(modelid != 0 && makeid !=0){
          pool.query('UPDATE public.car SET carname=$1, makeid=$2, modelid=$3 WHERE id=$4 ;', [name,makeid,modelid,id], (error, results) => {
            if (error) {
              throw error
            }
            response.status(201).send(`Car Updated with ID: ${id}`)
          })
        }
      })
    }
  })
  
  
}

const deleteCar = (request, response) => {
  const id = parseInt(request.params.id)

  pool.query('DELETE FROM car WHERE id = $1', [id], (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).send(`Car deleted with ID: ${id}`)
  })
}


module.exports = {
  getCars,
  getCarById,
  createCar,
  updateCar,
  getCarswithImage,
  deleteCar,
  uploadCarImage,
  getCarswithImageById
}
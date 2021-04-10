using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TESTING.BAL.Interfaces;
using TESTING.BE.BussinessEntities;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TESTING.WEBAPI.Controllers
{
    public class PassengerController : Controller
    {
        private readonly IPassengerManager _passengerManager;
        public PassengerController(IPassengerManager passengerManager)
        {
            _passengerManager = passengerManager;
        }
        // GET: api/Passenger
        public IList<Passenger> Get()
        {
            return _passengerManager.GetPassengersList();
        }

        // GET: api/Passenger/5
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                if (Guid.IsNullOrEmpty(id))
                {
                    return BadRequest("Invalid passenger id");
                }
                var passenger = _passengerManager.GetPassengersList();
                List<Passenger> list = (List<Passenger>)passenger;
                var item = list.Find(item1 => item1.Number == id);

                if (item != null)
                {
                    return Ok(item);
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }

        }

        private IHttpActionResult BadRequest(string v)
        {
            throw new NotImplementedException();
        }

        private IHttpActionResult Ok(Passenger item)
        {
            throw new NotImplementedException();
        }

        private IHttpActionResult InternalServerError()
        {
            throw new NotImplementedException();
        }

        // POST: api/Passenger
        public Passenger Post([FromBody] Passenger passenger)
        {
            return _passengerManager.AddPassenger(passenger);
        }

        // PUT: api/Passenger/5
        public Passenger Put([FromBody] Passenger passenger)
        {
            return _passengerManager.UpdatePassenger(passenger);
        }

        // DELETE: api/Passenger/5
        public bool Delete(Guid id)
        {
            return _passengerManager.RemovePassenger(id);
        }
    }
}
using DMS.BAL.Interfaces;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DMS.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/bookings")]
    public class BookingsController : ApiController
    {
        private readonly IBookingManager _bookingManager;
        public BookingsController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        [HttpGet]
        [Route("AllBookings")]
        public IHttpActionResult GetBookings()
        {
            return Ok(_bookingManager.GetAllBooking());
        }

        [HttpPut]
        [Route("Update")]
        public IHttpActionResult changeBooking([FromBody]Booking model)
        {
            return Ok(_bookingManager.UpdateBooking(model));
        }

        [HttpPut]
        [Route("UpdateStatus")]
        public IHttpActionResult changeBookingStatus([FromBody]Booking model)
        {
            return Ok(_bookingManager.UpdateBookingStatus(model));
        }

        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult deleteBooking([FromBody]Booking model)
        {
            return Ok(_bookingManager.DeleteBooking(model));
        }

    }
}

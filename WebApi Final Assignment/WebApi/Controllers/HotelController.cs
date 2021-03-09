using HM.BAL;
using HM.BAL.Interface;
using HM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    
    public class HotelController : ApiController
    {
        private readonly Ihotelmanager _hotelmanager;
        public HotelController(Ihotelmanager hotelmanager)
        {
            _hotelmanager = hotelmanager;
        }
       // GET: api/Hotel
        public IHttpActionResult Get()
        {
            //TODO:call hoteldetails


            List<Hotel> list = _hotelmanager.Getallhotels();
            return Ok(list);
        }

        // GET: api/Hotel/5
        public HttpResponseMessage Get(int id)
        {
            var hotel = _hotelmanager.GetHotel(id);
            return Request.CreateResponse<Hotel>(HttpStatusCode.OK, hotel);
        }

        // POST: api/Hotel
        public string Post([FromBody]Hotel model)
        {
            return _hotelmanager.Createhotel(model);
        }

        // PUT: api/Hotel/5
        public string Put([FromBody]Hotel model)
        {
            return _hotelmanager.Updatehotel(model);
        }

        // DELETE: api/Hotel/5
        public string Delete(int id)
        {
            return _hotelmanager.Deletehotel(id);
        }
        [Route("api/hotel/Getrooms")]
        public IHttpActionResult Getrooms()
        {
            //TODO:call hoteldetails


            List<Room> list = _hotelmanager.Getallrooms();
            return Ok(list);
        }
        [Route("api/hotel/createrooms")]
        public string createrooms([FromBody]Room model)
        {
            return _hotelmanager.Createroom(model);
        }
        [Route("api/hotel/bookrooms")]
        public string bookrooms([FromBody]Booking model)
        {
            return _hotelmanager.Bookroom(model);
        }
        [Route("api/hotel/Checkavailability")]
        public IHttpActionResult Checkavailability([FromBody]Booking model)
        {
            List<Booking> list = _hotelmanager.Checkbooking(model);
            return Ok(list);
        }
        [HttpDelete]
        [Route("api/hotel/removebooking")]
        public string removebooking(int id)
        {
            return _hotelmanager.deletebooking(id);
        }
        [HttpPut]
        [Route("api/hotel/changedate")]
        public string changedate([FromBody]Booking model)
        {
            return _hotelmanager.Updatebookingdate(model);
        }
        [HttpPut]
        [Route("api/hotel/Updatebookingstatus")]
        public string Updatebookingstatus([FromBody] Booking model)
        {
            return _hotelmanager.Updatebookingstatus(model);
        }
    }
}

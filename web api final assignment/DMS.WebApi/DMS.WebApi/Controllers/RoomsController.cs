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
    [RoutePrefix("api/rooms")]
    public class RoomsController : ApiController
    {

        private readonly IRoomManager _roomManager;

        public RoomsController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult CreateRoom([FromBody]Room model)
        {
            return Ok(_roomManager.CreateRoom(model));
        }

        [HttpPost]
        [Route("Book")]
        public IHttpActionResult BookRoom([FromBody]Booking model)
        {
            return Ok(_roomManager.BookRoom(model));
        }


        [HttpGet]
        [Route("CheckAvailablity/{id}/{date}")]
        public IHttpActionResult CheckAvailablity(int id, DateTime date)
        {
            return Ok(_roomManager.CheckRoomAvailability(id, date));
        }

        [HttpGet]
        [Route("{sortby?}")]
        public IHttpActionResult SortAllRooms(string sortby="price")
        {
            return Ok(_roomManager.SortRoom(sortby));
        }

    }
}

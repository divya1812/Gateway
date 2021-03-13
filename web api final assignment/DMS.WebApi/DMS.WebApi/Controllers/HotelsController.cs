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
    [RoutePrefix("api/hotels")]
    public class HotelsController : ApiController
    {
       private readonly IHotelManager _hotelManager;
        
        public HotelsController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;   
        }

        [HttpGet]
        [Route("AllHotels")]
        public IHttpActionResult Hotels()
        {
            return Ok(_hotelManager.GetAllHolels());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(_hotelManager.GetHotel(id));
        }


        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Post([FromBody]Hotel hotel)
        {
            return Ok(_hotelManager.CreateHotel(hotel));
        }


    }
}

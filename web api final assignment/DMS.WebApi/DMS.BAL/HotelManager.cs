using DMS.BAL.Interfaces;
using HMS.DAL.Repositories.Interfaces;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BAL
{
    public class HotelManager : IHotelManager
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;

        }

        public string CreateHotel(Hotel model)
        {
            return _hotelRepository.CreateHotel(model);
        }

        public List<Hotel> GetAllHolels()
        {
            return _hotelRepository.GetAllHolels();
        }

        public Hotel GetHotel(int id)
        {
            return _hotelRepository.GetHotel(id);
        }
    }
}

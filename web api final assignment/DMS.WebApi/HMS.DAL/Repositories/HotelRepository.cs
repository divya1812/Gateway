using AutoMapper;
using HMS.DAL.Repositories.Interfaces;
using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.DAL.Repositories
{
    public class HotelRepository : IHotelRepository
    {

        private readonly Database.HotelManagement _dbContext;
        
        public HotelRepository()
        {
            _dbContext = new Database.HotelManagement();
        }



        public string CreateHotel(Hotel model)
        {
            try
            {
                if (model != null)
                {
                     Database.Hotel hotel = Mapper.Map<Database.Hotel>(model);
                    _dbContext.Hotels.Add(hotel);
                    _dbContext.SaveChanges();

                    return "Successfully Added Hotel!!";
                }
                return "Hotel is Null!!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Hotel> GetAllHolels()
        {
            var hotels = _dbContext.Hotels.OrderBy(c => c.HotelName).ToList();
            
            List<Hotel> list = hotels.Select(Mapper.Map<Database.Hotel,Hotel>).ToList();

            return list;
        }

        public Hotel GetHotel(int id)
        {
   
            var dbHotel = _dbContext.Hotels.Where(h=>h.Id==id).FirstOrDefault();

            Hotel hotel = new Hotel();

            if (dbHotel != null)
            {
                hotel = Mapper.Map<Hotel>(dbHotel);
            }
            
            return hotel;

        }
    }
}

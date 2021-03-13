using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Models;

namespace HMS.DAL.Repositories.Interfaces
{
    public interface IHotelRepository
    {
        Hotel GetHotel(int id);
        List<Hotel> GetAllHolels();
        string CreateHotel(Hotel model);
    }
}

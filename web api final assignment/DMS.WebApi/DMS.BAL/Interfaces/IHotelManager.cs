using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BAL.Interfaces
{
    public interface IHotelManager
    {
        Hotel GetHotel(int id);
        List<Hotel> GetAllHolels();
        string CreateHotel(Hotel model);
    }
}

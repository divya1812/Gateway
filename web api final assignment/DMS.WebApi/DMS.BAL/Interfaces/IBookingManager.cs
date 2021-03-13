using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.BAL.Interfaces
{
    public interface IBookingManager
    {
        List<Booking> GetAllBooking();
        
        string UpdateBooking(Booking model);

        string UpdateBookingStatus(Booking model);
    
        string DeleteBooking(Booking model);
    }
}

using HMS.Models;
using System.Collections.Generic;

namespace HMS.DAL.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        List<Booking> GetAllBooking();
     
        string UpdateBooking(Booking model);
        
        string UpdateBookingStatus(Booking model);
        
        string DeleteBooking(Booking model);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMS.BAL.Interfaces;
using HMS.DAL.Repositories.Interfaces;
using HMS.Models;

namespace DMS.BAL
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingManager(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public string DeleteBooking(Booking model)
        {
            return _bookingRepository.DeleteBooking(model);
        }

        public List<Booking> GetAllBooking()
        {
            return _bookingRepository.GetAllBooking();
        }

        public string UpdateBooking(Booking model)
        {
            return _bookingRepository.UpdateBooking(model);
        }

        public string UpdateBookingStatus(Booking model)
        {
            return _bookingRepository.UpdateBookingStatus(model);
        }
    }
}

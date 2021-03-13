using System;

namespace HMS.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public DateTime? BookingDate { get; set; }
        public string BookingStatus { get; set; }
    }
}

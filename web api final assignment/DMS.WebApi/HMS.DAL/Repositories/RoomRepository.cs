using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using HMS.DAL.Repositories.Interfaces;
using HMS.Models;

namespace HMS.DAL.Repositories
{
    public class RoomRepository : IRoomRepository
    {

        private readonly Database.HotelManagement _dbContext;

        enum BookingsStatus
        {
            Optional,
            Definitive,
            Cancelled,
            Deleted
        }

        public RoomRepository()
        {
            _dbContext = new Database.HotelManagement();
        }

        public string BookRoom(Booking model)
        {
            try
            {
                if (model != null)
                {
                    Database.Booking dbBooking = _dbContext.Bookings
                        .Where(b => b.RoomId == model.RoomId
                        && DbFunctions.TruncateTime(b.BookingDate) == model.BookingDate)
                        .FirstOrDefault();
                    if (dbBooking == null)
                    {
                        model.BookingStatus = BookingsStatus.Optional.ToString();
                        dbBooking = Mapper.Map<Database.Booking>(model);

                        _dbContext.Bookings.Add(dbBooking);
                        _dbContext.SaveChanges();

                        return "Booking of room no " + model.RoomId + " has been confirmed on " + model.BookingDate + " with optional status";
                    }
                    else
                    {
                        return "Room is already booked on " + model.BookingDate;
                    }
                }
                return "ID and date can are required";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool CheckRoomAvailability(int id, DateTime date)
        {

            try
            {
                if ( date != null)
                {
                    var bookingRecord = _dbContext.Bookings
                        .Where(m => m.RoomId == id &&
                        DbFunctions.TruncateTime(m.BookingDate) == date)
                        .FirstOrDefault();

                    if (bookingRecord == null)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public string CreateRoom(Room model)
        {

            try
            {
                if (model != null)
                {
                    Database.Room room = Mapper.Map<Database.Room>(model);

                    _dbContext.Rooms.Add(room);
                    _dbContext.SaveChanges();

                    return "Room Creation Successful!!";
                }
                return "Room is Null!!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public List<Room> SortRoom(string sortBy)
        {

            List<Database.Room> dbRooms=new List<Database.Room>();
            
            switch (sortBy.ToLower())
            {
                case "city":
                    dbRooms = _dbContext.Hotels.Include(h => h.Rooms).SelectMany(h => h.Rooms).OrderBy(r=>r.Hotel.City).ToList();
                    break;
                case "pincode":
                    dbRooms = _dbContext.Hotels.Include(h => h.Rooms).SelectMany(h => h.Rooms).OrderBy(r => r.Hotel.Pincode).ToList();
                    break;
                case "category":
                    dbRooms = _dbContext.Rooms.OrderBy(r=>r.RoomCategory).ToList();
                    break;
                default:
                    dbRooms = _dbContext.Rooms.OrderBy(r => r.RoomPrice).ToList();
                    break;
            }

            List<Room> rooms = new List<Room>();

            if (dbRooms != null)
                rooms=dbRooms.Select(Mapper.Map<Database.Room,Room>).ToList();
            
            return rooms;

        }


    }
}

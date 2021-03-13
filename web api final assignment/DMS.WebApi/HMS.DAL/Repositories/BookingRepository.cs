using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HMS.DAL.Repositories.Interfaces;
using HMS.Models;

namespace HMS.DAL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        enum BookingsStatus
        {
            Optional,
            Definitive,
            Cancelled,
            Deleted
        }
        private readonly Database.HotelManagement _dbContext;

        public BookingRepository()
        {
            _dbContext = new Database.HotelManagement();
        }

        public string DeleteBooking(Booking model)
        {
            try
            {
                if (model != null)
                {
                    Database.Booking booking = _dbContext.Bookings.Find(model.Id);
                    if (booking != null)
                    {
                        booking.BookingStatus = BookingsStatus.Deleted.ToString();
                        _dbContext.SaveChanges();

                        return "Booking status of Booking Id" + model.Id + " has been changed to deleted";
                    }

                    return "Booking No " + model.Id + " is not there nothing to delete";

                }
                return "Booking id is missing";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Booking> GetAllBooking()
        {

            List<Database.Booking> dbBookings = _dbContext.Bookings.ToList();
            List<Booking> bookings = new List<Booking>();

            try
            {
                if (dbBookings != null)
                {
                    bookings = dbBookings.Select(Mapper.Map<Database.Booking, Booking>).ToList();
                }

            }
            catch (Exception)
            {
                return bookings;
            }

            return bookings;


        }

        public string UpdateBooking(Booking model)
        {

            if (model != null)
            {
                try
                {
                    Database.Booking dbBooking = _dbContext.Bookings
                        .Where(m => m.RoomId == model.RoomId)
                        .FirstOrDefault();

                    if (dbBooking != null)
                    {
                        if (dbBooking.BookingStatus == BookingsStatus.Optional.ToString() || dbBooking.BookingStatus == BookingsStatus.Definitive.ToString())
                        {   var oldDate =dbBooking.BookingDate;
                            dbBooking.BookingDate = model.BookingDate;
                            _dbContext.SaveChanges();

                            return "Booking of room Id " + model.RoomId + " has been Updated from " + oldDate + " to " + model.BookingDate + " with optional status";
                        }

                        return "Booking of room no " + model.RoomId + " has been " + dbBooking.BookingStatus + ". So the booking date cannot be modified";
                    }
                    else
                    {
                        return "Room  " + model.RoomId + " is not booked Yet .";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            return "Booking Model is empty";



        }

        public string UpdateBookingStatus(Booking model)
        {

            if (model.BookingStatus != null)
            {
                try
                {
                    Database.Booking dbBooking = _dbContext.Bookings
                        .Where(m => m.Id == model.Id)
                        .FirstOrDefault();
                    
                    if (dbBooking != null)
                    {
                        if (dbBooking.BookingStatus == BookingsStatus.Optional.ToString() || dbBooking.BookingStatus == BookingsStatus.Definitive.ToString())
                        {
                            dbBooking.BookingStatus = model.BookingStatus;
                            _dbContext.SaveChanges();

                            return "Status of Booking ID " + model.Id + " has been Updated to " + model.BookingStatus;
                        }
                        return "Booking of room no " + model.Id + " has been " + dbBooking.BookingStatus + ". So the booking status cannot be modified";
                    }
                    else
                    {
                        return "No Booking Found for Id "+model.Id;
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            return "Booking Model is empty";
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HM.Model;
using AutoMapper;
//using HM.DAL.Database;

namespace HM.DAL.Repository
{
    public class Hotelrepo : Ihotelrepo
    {
        private readonly Database.Hotelsdb _dbcontext;
       

        public Hotelrepo()
        {
            _dbcontext = new Database.Hotelsdb();
            
        }

        public string Bookroom(Booking model)
        {
            try
            {
                if (model!=null)
                {
                    var entity = _dbcontext.Roomslists.Find(model.Roomid);
                    Database.Roomslist rooms = new Database.Roomslist();
                    Database.Booking booking = new Database.Booking();
                    booking.Bookingdate = model.Bookingdate;
                    booking.Status = "CheckIn pending";
                    booking.Roomid = model.Roomid;
                    booking.IsActive = model.IsActive;
                    entity.IsActive = 1;
                    _dbcontext.Bookings.Add(booking);
                    _dbcontext.SaveChanges();
                    return "Room booked successfully";
                }
                return "Model is null";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public List<Booking> Checkbooking(Booking model)
        {
            List<Booking> booking = new List<Booking>();
            var entities = _dbcontext.Roomslists.ToList();

            if (entities!=null)
            {
                foreach (var item in entities)
                {
                    var data = _dbcontext.Bookings.Where(x => x.Roomid == item.Id & x.Bookingdate == model.Bookingdate);
                    if (data.Count()!=0)
                    {
                        foreach (var items in data)
                        {
                            Booking book = new Booking();
                            book.Roomid = items.Roomid;
                            if (items.IsActive==1)
                            {
                                book.Status = "True";
                            }
                            else
                            {
                                book.Status = "False";
                            }
                            booking.Add(book);
                        }
                    }
                    else
                    {
                        Booking book = new Booking();
                        book.Roomid = item.Id;
                        book.Status = "True";
                        book.IsActive = item.IsActive;
                        book.Bookingdate = book.Bookingdate;
                        booking.Add(book);
                    }
                }
                if (booking.Count == 0)
                    {
                        return null;
                    }
                    return booking;
                }
            else
            {
                return null;
            }
        }

        public string Createhotel(Hotel model)
        {
            try
            {
                if (model!=null)
                {
                    Database.Hotel entity = new Database.Hotel();

                    entity.Name = model.Name;
                    entity.Address = model.Address;
                    entity.City = model.City;
                    entity.Contactperson = model.Contactperson;
                    entity.Contactno = model.Contactno;
                    entity.Pincode = model.Pincode;
                    entity.Website = model.Website;
                    entity.Facebook = model.Facebook;
                    entity.IsActive = model.IsActive;
                    entity.Twitter = model.Twitter;
                    entity.Createddate = DateTime.Now;
                    entity.Createdby = model.Createdby;
                    entity.Updatedate = DateTime.Now;


                    _dbcontext.Hotels.Add(entity);
                    _dbcontext.SaveChanges();
                    return "Succesfully Added";
                }
                return "Model is empty";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Createroom(Room model)
        {
            try
            {
                if (model != null)
                {
                    Database.Roomslist entity = new Database.Roomslist();

                   
                    entity.Name = model.Name;
                    entity.Category = model.Category;
                    entity.Price = model.Price;
                    entity.City = model.City;
                    entity.IsActive = model.IsActive;
                    entity.Createddate = DateTime.Now;
                    entity.Createdby = model.Createdby;
                    entity.Updateddate = DateTime.Now;
                    entity.Updatedby = model.Updatedby;
                    entity.hotelID = model.hotelID;
                    // _dbcontext.Roomslists.Add(entity);
                    // _dbcontext.SaveChanges();
                    //var config = new MapperConfiguration(cfg => cfg.CreateMap<Room,Database.Roomslist>)();
                    //var mapper = new Mapper(config);

                    //entity = mapper.Map<Database.Roomslist>(model);
                    _dbcontext.Roomslists.Add(entity);
                    _dbcontext.SaveChanges();
                    return "Room added successfully";
                }
                return "Model is empty";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
         }

        public string deletebooking(int Id)
        {
            try
            {
                var data = _dbcontext.Bookings.Find(Id);
                var entity = _dbcontext.Roomslists.Find(data.Roomid);
                if (data != null)
                {
                    data.IsActive = 1;
                    data.Status = "Deleted";
                    entity.IsActive = 0;
                    _dbcontext.SaveChanges();
                    return "Booking deleted successfully";
                }
                return "no data found";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string Deletehotel(int Id)
        {
            try
            {
                var entity = _dbcontext.Hotels.Find(Id);

                if (entity!=null)
                {
                    _dbcontext.Hotels.Remove(entity);
                    _dbcontext.SaveChanges();
                    return "Deleted Successfully";
                }
                return "No Data Found";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }


        public List<Hotel> Getallhotels()
        {
            var entities = _dbcontext.Hotels.ToList();
            List<Hotel> hoteldetails = new List<Hotel>();
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    Hotel hotels = new Hotel();
                    hotels.Id = item.Id;
                    hotels.Name = item.Name;
                    hotels.Address = item.Address;
                    hotels.City = item.City;
                    hotels.Contactperson = item.Contactperson;
                    hotels.Contactno = item.Contactno;
                    hotels.Pincode = item.Pincode;
                    hotels.Website = item.Website;
                    hotels.Facebook = item.Facebook;
                    hotels.IsActive = item.IsActive;
                    hotels.Twitter = item.Twitter;
                    hotels.Createddate = item.Createddate;
                    hotels.Createdby = item.Createdby;
                    hotels.Updatedate = item.Updatedate;
                    hotels.Updatedby = item.Updatedby;

                    hoteldetails.Add(hotels);
                    
                }
                
            }
            return hoteldetails;
        }

        public List<Room> Getallrooms()
        {

            var entities = _dbcontext.Hotels.ToList();
            var collection = _dbcontext.Roomslists.ToList();
            List<Room> roomdetails = new List<Room>();
            List<Hotel> hoteldetails = new List<Hotel>();
            if (entities != null)
            {
                foreach (var item in collection)
                {
                    Room rooms = new Room();
                    rooms.Id = item.Id;
                    rooms.Name = item.Name;
                    rooms.Price = item.Price;
                    rooms.Category = item.Category;
                    rooms.Createdby = item.Createdby;
                    rooms.Createddate = DateTime.Now;
                    rooms.IsActive = item.IsActive;
                    rooms.Updatedby = item.Updatedby;
                    rooms.City = item.City;
                    rooms.hotelID = item.hotelID;
                    roomdetails.Add(rooms);
                }
            }
            return roomdetails;
        }
        public Hotel GetHotel(int Id)
        {
            var entity = _dbcontext.Hotels.Find(Id);
            Hotel hotels = new Hotel();
            if (entity!=null)
            { 
            
            hotels.Id = entity.Id;
            hotels.Name = entity.Name;
            hotels.Address = entity.Address;
            hotels.City = entity.City;
            hotels.Contactperson = entity.Contactperson;
            hotels.Contactno = entity.Contactno;
            hotels.Pincode = entity.Pincode;
            hotels.Website = entity.Website;
            hotels.Facebook = entity.Facebook;
            hotels.IsActive = entity.IsActive;
            hotels.Twitter = entity.Twitter;
            hotels.Createddate = entity.Createddate;
            hotels.Createdby = entity.Createdby;
            hotels.Updatedate = entity.Updatedate;
            hotels.Updatedby = entity.Updatedby;
            }
            return hotels;
          
        }

        public string Updatebookingdate(Booking model)
        {
            try
            {
                var entity = _dbcontext.Bookings.Find(model.Id);
                if (model!=null)
                {
                    entity.Bookingdate = model.Bookingdate;

                    _dbcontext.SaveChanges();
                    return "Booking date update successfully";
                }
                return "No data found";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Updatebookingstatus(Booking model)
        {
            try
            {
                var entity = _dbcontext.Bookings.Find(model.Id);
                if (model != null)
                {
                    entity.Status = model.Status;

                    _dbcontext.SaveChanges();
                    return "Booking status update successfully";
                }
                return "No data found";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string Updatehotel(Hotel model)
        {
            try
            {
                var entity = _dbcontext.Hotels.Find(model.Id);
                if (model != null)
                {
                    

                    entity.Name = model.Name;
                    entity.Address = model.Address;
                    entity.City = model.City;
                    entity.Contactperson = model.Contactperson;
                    entity.Contactno = model.Contactno;
                    entity.Pincode = model.Pincode;
                    entity.Website = model.Website;
                    entity.Facebook = model.Facebook;
                    entity.IsActive = model.IsActive;
                    entity.Twitter = model.Twitter;
                   
                    entity.Createdby = model.Createdby;
                    entity.Updatedate = DateTime.Now;


                    
                    _dbcontext.SaveChanges();
                    return "Successfully added";
                }
                return "No data found";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}

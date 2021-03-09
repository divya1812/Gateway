using HM.BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HM.Model;
using HM.DAL.Repository;

namespace HM.BAL
{
    public class Hotelmanager : Ihotelmanager
    {
        private readonly Ihotelrepo _hotelrepo;
        public Hotelmanager(Ihotelrepo hotelrepo)
        {
            _hotelrepo = hotelrepo;
        }

        public string Bookroom(Booking model)
        {
            return _hotelrepo.Bookroom(model);
        }

        public List<Booking> Checkbooking(Booking model)
        {
            return _hotelrepo.Checkbooking(model);
        }

        public string Createhotel(Hotel model)
        {
            return _hotelrepo.Createhotel(model);
        }

        public string Createroom(Room model)
        {
            return _hotelrepo.Createroom(model);
        }

        public string deletebooking(int Id)
        {
            return _hotelrepo.deletebooking(Id);
        }

        public string Deletehotel(int Id)
        {
            return _hotelrepo.Deletehotel(Id);
        }

        public List<Hotel> Getallhotels()
        {
            return _hotelrepo.Getallhotels();
        }

        public List<Room> Getallrooms()
        {
            return _hotelrepo.Getallrooms();
        }

        public Hotel GetHotel(int Id)
        {
            return _hotelrepo.GetHotel(Id);
        }

        public string Updatebookingdate(Booking model)
        {
            return _hotelrepo.Updatebookingdate(model);
        }

        public string Updatebookingstatus(Booking model)
        {
            return _hotelrepo.Updatebookingstatus(model);
        }

        public string Updatehotel(Hotel model)
        {
            return _hotelrepo.Updatehotel(model);
        }
    }
}

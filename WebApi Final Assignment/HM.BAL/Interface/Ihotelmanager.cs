using HM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.BAL.Interface
{
    public interface Ihotelmanager
    {
        Hotel GetHotel(int Id);
        List<Hotel> Getallhotels();
        string Createhotel(Hotel model);
        string Updatehotel(Hotel model);
        string Deletehotel(int Id);
        string Createroom(Room model);
        List<Room> Getallrooms();

        string Bookroom(Booking model);
        List<Booking> Checkbooking(Booking model);
        string Updatebookingdate(Booking model);
        string Updatebookingstatus(Booking model);
        string deletebooking(int Id);
    }
}

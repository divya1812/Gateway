using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Models;
namespace HMS.DAL.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        List<Room> SortRoom(string sortBy);
        string CreateRoom(Room model);
        bool CheckRoomAvailability(int id, DateTime date);
        string BookRoom(Booking model);
    }
}

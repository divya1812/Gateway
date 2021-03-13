using HMS.Models;
using System;
using System.Collections.Generic;

namespace DMS.BAL.Interfaces
{
    public interface IRoomManager
    {
        List<Room> SortRoom(string sortBy);

        string CreateRoom(Room model);

        bool CheckRoomAvailability(int id, DateTime date);

        string BookRoom(Booking model);
       

    }
}

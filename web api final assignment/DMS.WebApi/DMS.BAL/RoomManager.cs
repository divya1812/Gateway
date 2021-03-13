using System;
using System.Collections.Generic;
using DMS.BAL.Interfaces;
using HMS.DAL.Repositories.Interfaces;
using HMS.Models;

namespace DMS.BAL
{
    public class RoomManager : IRoomManager
    {
        private readonly IRoomRepository _roomRepository;

        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public string BookRoom(Booking model)
        {
            return _roomRepository.BookRoom(model);
        }

        public bool CheckRoomAvailability(int id, DateTime date)
        {
            return _roomRepository.CheckRoomAvailability(id,date);
        }


        public string CreateRoom(Room model)
        {
            return _roomRepository.CreateRoom(model);
        }

        public List<Room> SortRoom(string sortBy)
        {
            return _roomRepository.SortRoom(sortBy);
        }
    }
}

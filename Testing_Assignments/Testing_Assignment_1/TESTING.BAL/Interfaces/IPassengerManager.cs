using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTING.BE.BussinessEntities;

namespace TESTING.BAL.Interfaces
{
    public interface IPassengerManager
    {
        bool RemovePassenger(Guid passengerId);
        Passenger AddPassenger(Passenger passenger);
        IList<Passenger> GetPassengersList();
        Passenger GetPassenger(Guid passengerId);
        Passenger UpdatePassenger(Passenger passenger);
    }
}

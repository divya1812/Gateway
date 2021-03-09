using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTING.BE.BussinessEntities;

namespace TESTING.BAL.Repositories
{
    public static class PassengerRepository
    {
        public static List<Passenger> passengers = new List<Passenger>();

        static PassengerRepository()
        {
            AddPassenger(new Passenger { Number = Guid.NewGuid(), FirstName = "P1", LastName = "LAST_NAME1", ContactNo = "54565614" });
            AddPassenger(new Passenger { Number = Guid.NewGuid(), FirstName = "P2", LastName = "LAST_NAME2", ContactNo = "1456421" });
            AddPassenger(new Passenger { Number = Guid.NewGuid(), FirstName = "P3", LastName = "LAST_NAME3", ContactNo = "1543548" });
            AddPassenger(new Passenger { Number = Guid.NewGuid(), FirstName = "P4", LastName = "LAST_NAME4", ContactNo = "5436842" });
            AddPassenger(new Passenger { Number = Guid.NewGuid(), FirstName = "P5", LastName = "LAST_NAME5", ContactNo = "8421572" });
            AddPassenger(new Passenger { Number = Guid.NewGuid(), FirstName = "P6", LastName = "LAST_NAME6", ContactNo = "21498601" });

        }
        public static Passenger AddPassenger(Passenger passenger)
        {
            passengers.Add(passenger);
            return passenger;
        }
        public static IList<Passenger> GetPassengers()
        {
            return passengers;
        }
        public static Passenger GetPassengerById(Guid Id)
        {
            return passengers.FirstOrDefault(x => x.Number == Id);
        }
        public static bool DeletePassenger(Guid passengerId)
        {
            return passengers.Remove(GetPassengerById(passengerId));
        }
        public static Passenger UpdatePassenger(Passenger passenger)
        {
            Passenger passengerToUpdate = GetPassengerById(passenger.Number);
         
            if (passengerToUpdate == null)
                return null;
            passengerToUpdate.ContactNo = passenger.ContactNo;
            passengerToUpdate.FirstName = passenger.FirstName;
            passengerToUpdate.LastName = passenger.LastName;
            return passengerToUpdate;
        }
    }
}

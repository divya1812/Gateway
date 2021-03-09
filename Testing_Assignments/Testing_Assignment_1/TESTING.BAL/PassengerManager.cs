using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTING.BAL.Interfaces;
using TESTING.BAL.Repositories;
using TESTING.BE.BussinessEntities;

namespace TESTING.BAL
{
    public class PassengerManager : IPassengerManager
    {
        readonly Dictionary<Guid, Passenger> _passenger = new Dictionary<Guid, Passenger>();
        private Passenger GeneratePassengerWithId(Passenger passenger)
        {
            Guid passengerId = Guid.NewGuid();

            passenger.Number = passengerId;
            _passenger.Add(passengerId, passenger);

            return passenger;
        }
        public Passenger AddPassenger(Passenger passenger)
        {
            return PassengerRepository.AddPassenger(GeneratePassengerWithId(passenger));
        }

        public Passenger GetPassenger(Guid passengerId)
        {
            return PassengerRepository.GetPassengerById(passengerId);
        }

        public IList<Passenger> GetPassengersList()
        {
            return PassengerRepository.GetPassengers();
        }

        public bool RemovePassenger(Guid passengerId)
        {
            return PassengerRepository.DeletePassenger(passengerId);
        }

        public Passenger UpdatePassenger(Passenger passenger)
        {

            return PassengerRepository.UpdatePassenger(passenger);
        }
    }
}

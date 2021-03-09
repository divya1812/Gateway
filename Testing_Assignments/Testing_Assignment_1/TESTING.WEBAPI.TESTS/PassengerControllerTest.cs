using Moq;
using System;
using System.Linq;
using TESTING.BAL.Interfaces;
using TESTING.BAL;
using TESTING.WEBAPI.Controllers;
using Xunit;
using TESTING.BE.BussinessEntities;
using System.Collections.Generic;

namespace TESTING.WEBAPI.TESTS
{
    public class PassengerControllerTest
    {
        private readonly Mock<IPassengerManager> mockDataRepository = new Mock<IPassengerManager>();
        private readonly PassengerController _passengerController;
        private PassengerManager _pm;
        public PassengerControllerTest()
        {
            _passengerController = new PassengerController(mockDataRepository.Object);
            _pm = new PassengerManager();
        }
        [Fact]
        public void Test_AddUser()
        {

            var newPassenger = new Passenger();
            newPassenger.FirstName = "divya";
            newPassenger.LastName = "chhabaria";
            newPassenger.ContactNo = "1234";

            var addedPassenger = _pm.AddPassenger(newPassenger);

            // Act
            var response = mockDataRepository.Setup(
                x => x.AddPassenger(newPassenger)
                )
                .Returns(addedPassenger);
            var result = _passengerController.Post(newPassenger);

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void GetPassengerTest()
        {
            // Arrange
            var resultobj = mockDataRepository.Setup(x => x.GetPassengersList()).Returns(GetPassengers());

            //Act
            var response = _passengerController.Get();

            //Assert
            Assert.Equal(3, response.Count);
        }

        [Fact]
        public void Test_UpdatePassenger()
        {
            // Arrange
            IList<Passenger> passengers = _pm.GetPassengersList();
            var passenger1 = passengers.First<Passenger>();
            passenger1.FirstName = "updated first name";
            passenger1.LastName = "updated last name";
            passenger1.ContactNo = "1234";

            var updatedPassenger = _pm.UpdatePassenger(passenger1);

            // Act
            var resultObj = mockDataRepository.Setup(x => x.UpdatePassenger(passenger1)).Returns(updatedPassenger);
            var response = _passengerController.Put(passenger1);
            // Assert
            Assert.Equal(passenger1, response);
        }
        [Fact]
        public void Test_DeletePassenger()
        {

            IList<Passenger> passengers = _pm.GetPassengersList();
            var passenger1 = passengers.First<Passenger>();

            var isDeleted = _pm.RemovePassenger(passenger1.Number);

            // Assert
            Assert.True(isDeleted);
        }

        private static IList<Passenger> GetPassengers()
        {
            IList<Passenger> passengers = new List<Passenger>()
            {
                new Passenger(){ Number=Guid.NewGuid(),FirstName="p1",LastName="LN1",ContactNo="564645"},
                new Passenger(){ Number=Guid.NewGuid(),FirstName="p2",LastName="LN2",ContactNo="25455"},
                new Passenger(){ Number=Guid.NewGuid(),FirstName="p3",LastName="LN3",ContactNo="245454"}
            };
            return passengers;
        }
    }
}

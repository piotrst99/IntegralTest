using System;
//using Xunit;
using NUnit;
using NUnit.Framework;
using CarManageApp.DatabaseContext;
using NUnit.Framework.Internal;
using Data.Entities;
using CarManageApp.Controllers;
using System.Linq;

// https://www.youtube.com/watch?v=xs8gNQjCXw0
// https://code-maze.com/aspnet-core-integration-testing/
// https://www.modestprogrammer.pl/testujemy-operacje-na-bazie-danych-wprowadzenie-do-testow-integracyjnych-w-dot-net
// https://www.fearofoblivion.com/asp-net-core-integration-testing

namespace IntegralTest {
    [TestFixture]
    public class UnitTest1 {
        private readonly AppDbcontext _appDbContext;

        [Test, Isolated]
        public void Test1() {
            Car car = new Car() {
                Id = 1,
                Mark = "Fiat",
                Model = "Seicento",
                Course = 123000,
                RegisterNumber = "KN 12345"
            };

            _appDbContext.Cars.Add(car);
            var carCount = _appDbContext.Cars.Count(q => q.Id == car.Id);
            //Assert.That(carCount, Is.EqualTo(1));
            Assert.AreEqual(carCount, 1);
        }
    }
}

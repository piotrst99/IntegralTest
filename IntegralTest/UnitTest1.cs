using System;
using NUnit;
using NUnit.Framework;
using CarManageApp.DatabaseContext;
using NUnit.Framework.Internal;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// https://www.youtube.com/watch?v=xs8gNQjCXw0
// https://code-maze.com/aspnet-core-integration-testing/
// https://www.modestprogrammer.pl/testujemy-operacje-na-bazie-danych-wprowadzenie-do-testow-integracyjnych-w-dot-net
// https://www.fearofoblivion.com/asp-net-core-integration-testing

namespace IntegralTest {
    [TestFixture]
    public class UnitTest1 {
        private readonly AppDbcontext _appDbContext = new AppDbcontext(
            options: new DbContextOptionsBuilder<AppDbcontext>()
                .UseSqlServer("Server=localhost; Initial Catalog=CarDatabase; Integrated Security=True;")
                .Options
            );

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

            //_carService.AddCar(car);
            //var carCount2 = _carService.GetCar(car.Id);

            Assert.AreEqual(carCount, 1);
        }

        [Test]
        public void Test2() {
            Assert.AreEqual(0, 0);
        }
    }
}

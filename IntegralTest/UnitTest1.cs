using System;
using NUnit;
using NUnit.Framework;
using CarManageApp.DatabaseContext;
using NUnit.Framework.Internal;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CarManageApp.Services;

// https://www.youtube.com/watch?v=xs8gNQjCXw0
// https://code-maze.com/aspnet-core-integration-testing/
// https://www.modestprogrammer.pl/testujemy-operacje-na-bazie-danych-wprowadzenie-do-testow-integracyjnych-w-dot-net
// https://www.fearofoblivion.com/asp-net-core-integration-testing

namespace IntegralTest {
    [TestFixture]
    public class UnitTest1 {
        private static AppDbcontext _appDbContext = new AppDbcontext(
            options: new DbContextOptionsBuilder<AppDbcontext>()
                .UseSqlServer("Server=localhost; Initial Catalog=CarDatabase; Integrated Security=True;")
                .Options
            );
        private ICarService _carService = new CarService(_appDbContext);

        [Test, Isolated]
        public void Test1() {

            Car car = new Car() {
                Mark = "Fiat",
                Model = "Seicento",
                Course = 123000,
                RegisterNumber = "KN 12345"
            };

            _carService.AddCar(car);
            var carCount = _appDbContext.Cars.Count(q => q.Id == car.Id);
            Assert.AreEqual(carCount, 1);
            Assert.AreNotEqual(carCount, 0);
        }

        [Test]
        public void Test2() {
            Car car = new Car() {
                Mark = "Fiat",
                Model = "Seicento",
                Course = 123000,
                RegisterNumber = "KN 12345"
            };

            var option = new DbContextOptionsBuilder<AppDbcontext>()
                .UseSqlServer("Server=localhost; Initial Catalog=CarDatabase; Integrated Security=True;")
                .Options;

            using (var context = new AppDbcontext(option)) {
                context.Add(car);
                context.SaveChanges();
                var carCount = _appDbContext.Cars.Count(q => q.Id == car.Id);
                Assert.AreEqual(carCount, 1);
                Assert.AreNotEqual(carCount, 0);
            }
        }
    }
}

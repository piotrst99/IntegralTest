using System;
using NUnit;
using NUnit.Framework;
using CarManageApp.DatabaseContext;
using NUnit.Framework.Internal;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CarManageApp.Services;
using System.Collections.Generic;

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
            int carCount = _appDbContext.Cars.Count(q => q.Id == car.Id);
            Car carItem = _appDbContext.Cars.FirstOrDefault(q => q.Id == car.Id);

            Assert.AreEqual(carCount, 1);
            Assert.AreNotEqual(carCount, 0);
            Assert.AreEqual(carItem, car);
            Assert.AreNotEqual(carItem, null);
        }

        [Test, Isolated]
        public void Test1_1() {
            Car car = new Car() {
                Mark = "Fiat",
                Model = "Seicento",
                Course = 123000,
                RegisterNumber = "KN 12345"
            };

            Car car2 = new Car() {
                Mark = "Suzuki",
                Model = "Baleno",
                Course = 111,
                RegisterNumber = "KGR K888"
            };

            _carService.AddCar(car);
            _carService.AddCar(car2);
            List<Car> carList = _appDbContext.Cars.ToList();
            Car carItem1 = carList.FirstOrDefault(q => q.Id == car.Id);
            Car carItem2 = carList.FirstOrDefault(q => q.Id == car2.Id);

            Assert.AreEqual(carList.Count, 2); //
            Assert.AreNotEqual(carList.Count, 0);
            Assert.AreEqual(carItem1, car);
            Assert.AreNotEqual(carItem1, null);
            Assert.AreEqual(carItem2, car2);
            Assert.AreNotEqual(carItem2, null);
        }

        [Test, Isolated]
        public void Test1_2() {
            Car car = new Car() {
                Id = 17,
                Mark = "Ford",
                Model = "Fiesta",
                Course = 4444,
                RegisterNumber = "KLI 6969"
            };
            _carService.RemoveCar(17);

            int carCount = _appDbContext.Cars.Count(q => q.Id == car.Id);
            Car carItem = _appDbContext.Cars.FirstOrDefault(q => q.Id == car.Id);

            Assert.AreEqual(carCount, 0);
            Assert.AreNotEqual(carCount, 1);
            Assert.AreEqual(carItem, null);
            Assert.AreNotEqual(carItem, car);
        }

        [Test, Isolated]
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

                int carCount = context.Cars.Count(q => q.Id == car.Id);
                Car carItem = context.Cars.Where(q => q.Id == car.Id).FirstOrDefault();

                Assert.AreEqual(carCount, 1);
                Assert.AreNotEqual(carCount, 0);
                Assert.AreEqual(carItem, car);
                Assert.AreNotEqual(carItem, null);
            }
        }
    }
}

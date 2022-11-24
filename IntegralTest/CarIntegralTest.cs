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

namespace IntegralTest {
    [TestFixture]
    public class CarIntegralTest {
        private static AppDbcontext _appDbContext = new AppDbcontext(
            options: new DbContextOptionsBuilder<AppDbcontext>()
                .UseSqlServer("Server=localhost; Initial Catalog=CarDatabase; Integrated Security=True;")
                .Options
            );
        private ICarService _carService = new CarService(_appDbContext);

        [Test, Isolated]
        public void AddCarToDatabase_AddCar_ShouldBeOk() {
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
        public void AddMoreCarToDatabase_AddCar_ShouldBeOk() {
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

            Assert.AreEqual(carList.Count, 12);
            Assert.AreNotEqual(carList.Count, 0);
            Assert.AreEqual(carItem1, car);
            Assert.AreNotEqual(carItem1, null);
            Assert.AreEqual(carItem2, car2);
            Assert.AreNotEqual(carItem2, null);
        }

        [Test, Isolated]
        public void RemoveCarToDatabase_RemoveCar_ShouldBeOk() {
            _carService.RemoveCar(10);

            int carCount = _appDbContext.Cars.Count(q => q.Id == 10);
            Car carItem = _appDbContext.Cars.FirstOrDefault(q => q.Id == 10);

            Assert.AreEqual(carCount, 0);
            Assert.AreNotEqual(carCount, 1);
            Assert.AreEqual(carItem, null);
        }

        [Test]
        public void GetCarFromDatabase_GetCar_ShouldBeOk() {
            Car car = _carService.GetCar(5);
            Assert.AreEqual(car.Id, 5);
            Assert.AreNotEqual(car, null);

            Car car2 = _carService.GetCar(100);
            Assert.AreEqual(car2, null);
        }

        [Test]
        public void GetCarsFromDatabase_GetCars_ShouldBeOk() {
            IEnumerable<Car> cars = _carService.GetCars();
            Assert.AreEqual(cars.Count(), 10);
        }

        [Test]
        public void GetEmailFromDatabase_GetCarsByProductionYear_ShouldBeOk() {
            IEnumerable<Car> carsList = _carService.GetCarsByProductionYear(2022);
            Assert.AreEqual(carsList.Count(), 2);

            IEnumerable<Car> carsList2 = _carService.GetCarsByProductionYear(2010);
            Assert.AreEqual(carsList2.Count(), 1);

            IEnumerable<Car> carsList3 = _carService.GetCarsByProductionYear(2023);
            Assert.AreEqual(carsList3.Count(), 0);
        }

        [Test]
        public void GetCarFromDatabase_GetCarByRegisterNumber_ShouldBeOk() {
            Car car = _carService.GetCarByRegisterNumber("RJA 23464");
            Assert.AreEqual(car.RegisterNumber, "RJA 23464");

            Car car2 = _carService.GetCarByRegisterNumber("WW 12345");
            Assert.AreEqual(car2, null);
        }

        [Test]
        public void GetCarCourseFromDatabase_GetCarCource_ShouldBeOk() {
            int carCourse = _carService.GetCarCource(3);
            Assert.AreEqual(carCourse, 124765);

            int carCourse2 = _carService.GetCarCource(11);
            Assert.AreEqual(carCourse2, 0);
        }

        [Test]
        public void GetModelsByMarkFromDatabase_GetModelsByMark_ShouldBeOk() {
            IEnumerable<string> models = _carService.GetModelsByMark("Audi");
            Assert.AreEqual(models.Count(), 2);

            IEnumerable<string> models2 = _carService.GetModelsByMark("Skoda");
            Assert.AreEqual(models2.Count(), 0);
        }
    }
}

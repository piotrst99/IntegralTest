using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CarManageApp.DatabaseContext;
using NUnit.Framework.Internal;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using CarManageApp.Services;

namespace IntegralTest {
    [TestFixture]
    public class CarRepairIntegralTest {
        // tworzenie połączenia do bazy danych
        private static AppDbcontext _appDbContext = new AppDbcontext(
            options: new DbContextOptionsBuilder<AppDbcontext>()
                .UseSqlServer("Server=localhost; Initial Catalog=CarDatabase; Integrated Security=True;")
                .Options
            );
        private ICarRepairService _carRepairService = new CarRepairService(_appDbContext);
        
        // poniera dane dotyczacej naprawy pojazdu - powinien zwrocic obiekt klasy CAr
        [Test]
        public void GetCarRepairFromDatabase_GetCarRepair_ShouldBeOk() {
            CarRepair carRepair = _appDbContext.CarRepairs.Where(q => q.Id == 2).FirstOrDefault();
            Assert.AreEqual(carRepair.Id, 2);
            Car car = _appDbContext.Cars.Where(q => q.Id == carRepair.CarId).FirstOrDefault();
            Assert.AreEqual(car.Id, 3);
        }

        // pobranie lise napraw w danym dniu - powinien zwroicic liste oraz liczbw obiektow
        [Test]
        public void GetCarRepairByDateFromDatabase_GetCarRepairsByRepairDate_ShouldBeOk() {
            IEnumerable<CarRepair> carRepairs = _appDbContext.CarRepairs.Where(q => q.RepairDate == "2022-11-24");
            Assert.AreEqual(carRepairs.Count(), 2);

            IEnumerable<CarRepair> carRepairs2 = _appDbContext.CarRepairs.Where(q => q.RepairDate == null);
            Assert.AreEqual(carRepairs2.Count(), 3);

            IEnumerable<CarRepair> carRepairs3 = _appDbContext.CarRepairs.Where(q => q.RepairDate == "2023-01-01");
            Assert.AreEqual(carRepairs3.Count(), 0);
        }

        // pobranie kosztu naprawy z bazy danych - powinien zwrocic wartosc
        [Test]
        public void GetCostRepairFromDatabase_GetCost_ShouldBeOk() {
            int costRepair = _appDbContext.CarRepairs.Where(q => q.CarId == 10).FirstOrDefault().Cost;
            Assert.IsTrue(costRepair == 565 || costRepair == 5000);

            int? costRepair2 = _appDbContext.CarRepairs.Where(q => q.CarId == 15).FirstOrDefault()?.Cost;
            Assert.IsTrue(!costRepair2.HasValue);
        }

        // pobranie pojazdow na podstawie id klienta - powinien zwrocic liczbe pojazdow
        [Test]
        public void GetCarsRepairFromDatabase_GetCarsByCustomerId_ShouldBeOk() {
            int carRepairsCount = _appDbContext.CarRepairs.Count(q => q.CustomerId == 1);
            Assert.IsTrue(carRepairsCount == 2);

            int carRepairsCount2 = _appDbContext.CarRepairs.Count(q => q.CustomerId == 69);
            Assert.IsTrue(carRepairsCount2 == 0);
        }

        // dodanie danyc naprawy pojazdu do bazy danych - powinien zwrocic warosc
        [Test, Isolated]
        public void AddCarRepairToDatabase_AddCarRepair_ShouldBeOk() {
            CarRepair carRepair = new CarRepair {
                CarId = 4,
                CustomerId = 1,
                RepairDate = "2022-10-01",
                Cost = 200,
                IsRepair = true,
                Description = "Brak opisu"
            };

            int countOfRepairsBefore = _appDbContext.CarRepairs.Count();
            Assert.AreEqual(countOfRepairsBefore, 7);
            _carRepairService.AddCarRepair(carRepair);
            int countOfRepairsAfter = _appDbContext.CarRepairs.Count();
            Assert.AreEqual(countOfRepairsAfter, 8);
        }

        // akrualizuje dane naprawy - dane powinny sie roznic 
        [Test, Isolated]
        public void UpdateCarRepairToDatabase_UpdateCarRepair_ShouldBeOk() {
            CarRepair carRepairToUpdate = new CarRepair {
                Id = 1,
                CarId = 1,
                CustomerId = 6,
                RepairDate = "2022-08-11",
                Cost = 200,
                IsRepair = true,
                Description = "Wymiana felgów"
            };

            CarRepair carRepairOld = _appDbContext.CarRepairs.FirstOrDefault(q => q.Id == 1);

            int carRepairsCountBeforeUpdate = _appDbContext.CarRepairs.Count();
            Assert.IsTrue(carRepairsCountBeforeUpdate == 7);
            
            _carRepairService.UpdateCarRepair(carRepairToUpdate);

            int carRepairsCountAfterUpdate = _appDbContext.CarRepairs.Count();
            Assert.IsTrue(carRepairsCountAfterUpdate == 7);

            Assert.AreNotEqual(carRepairOld,carRepairToUpdate);
        }
    }
}

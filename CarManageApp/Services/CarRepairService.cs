using CarManageApp.DatabaseContext;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarManageApp.Services {
    public class CarRepairService : ICarRepairService {
        private AppDbcontext _dbContext;

        // konstruktor z wstrzykiwaniem zależności
        public CarRepairService(AppDbcontext appDbcontext) {
            _dbContext = appDbcontext;
        }

        // dodanie danych do bazy dotyczącej naprawy pojazdu
        public int AddCarRepair(CarRepair carRepair) {
            _dbContext.CarRepairs.Add(carRepair);
            return _dbContext.SaveChanges();
        }

        // pobranie danych naprawy na podstawie jego id
        public IEnumerable<Car> GetCarsByCustomerId(int customerId) {
            return _dbContext.CarRepairs.Where(q => q.CustomerId == customerId).Select(x => x.Car);
        }

        // zwraca listę samochodów na podstawie id klienta
        public CarRepair GetCarRepair(int repairId) {
            return _dbContext.CarRepairs.FirstOrDefault(q => q.Id == repairId);
        }

        // zwraca listę napraw w danym dniu
        public IEnumerable<CarRepair> GetCarRepairsByRepairDate(string date) {
            return _dbContext.CarRepairs.Where(q => q.RepairDate == date);
        }

        // zwraca koszt naprawy
        public int GetCost(int repairId) {
            return _dbContext.CarRepairs.FirstOrDefault(q => q.Id == repairId).Cost;
        }

        // aktualizacja danych dotyczącej naprawy
        public int UpdateCarRepair(CarRepair carRepair) {
            CarRepair carRepairToUpdate = _dbContext.CarRepairs.FirstOrDefault(q => q.Id == carRepair.Id);
            if (carRepairToUpdate == null) return -1;
            
            carRepairToUpdate.CarId = carRepair.CarId;
            carRepairToUpdate.CustomerId = carRepair.CustomerId;
            carRepairToUpdate.RepairDate = carRepair.RepairDate;
            carRepairToUpdate.Cost = carRepair.Cost;
            carRepairToUpdate.IsRepair = carRepair.IsRepair;
            carRepairToUpdate.Description = carRepair.Description;
            
            _dbContext.CarRepairs.Update(carRepairToUpdate);
            return _dbContext.SaveChanges();
        }
    }
}

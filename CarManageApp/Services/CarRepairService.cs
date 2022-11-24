using CarManageApp.DatabaseContext;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarManageApp.Services {
    public class CarRepairService : ICarRepairService {
        private AppDbcontext _dbContext;

        public CarRepairService(AppDbcontext appDbcontext) {
            _dbContext = appDbcontext;
        }

        public int AddCarRepair(CarRepair carRepair) {
            _dbContext.CarRepairs.Add(carRepair);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Car> GetCarsByCustomerId(int customerId) {
            return _dbContext.CarRepairs.Where(q => q.CustomerId == customerId).Select(x => x.Car);
        }

        public CarRepair GetCarRepair(int repairId) {
            return _dbContext.CarRepairs.FirstOrDefault(q => q.Id == repairId);
        }

        public IEnumerable<CarRepair> GetCarRepairsByRepairDate(string date) {
            return _dbContext.CarRepairs.Where(q => q.RepairDate == date);
        }

        public int GetCost(int repairId) {
            return _dbContext.CarRepairs.FirstOrDefault(q => q.Id == repairId).Cost;
        }

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

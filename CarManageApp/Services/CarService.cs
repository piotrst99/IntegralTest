using CarManageApp.DatabaseContext;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManageApp.Services {
    public class CarService : ICarService {
        private AppDbcontext _dbContext;

        public CarService(AppDbcontext appDbContext) {
            _dbContext = appDbContext;
        }

        public Car GetCar(int carId) {
            return _dbContext.Cars.Where(x => x.Id == carId).FirstOrDefault();
        }

        public IEnumerable<Car> GetCars() {
            return _dbContext.Cars;
        }

        public Car GetCarByRegisterNumber(string registerNumber) {
            return _dbContext.Cars.Where(x => x.RegisterNumber == registerNumber).FirstOrDefault();
        }

        public int GetCarCource(int carId) {
            return _dbContext.Cars.Where(x => x.Id == carId).Select(y => y.Course).FirstOrDefault();
        }

        public IEnumerable<string> GetModelsByMark(string mark) {
            return _dbContext.Cars.Where(x => x.Mark == mark).Select(y => y.Model).Distinct();
        }

        public int AddCar(Car car) {
            _dbContext.Cars.Add(car);
            return _dbContext.SaveChanges();
        }

        public int RemoveCar(int carId) {
            _dbContext.Cars.Remove(_dbContext.Cars.Where(q=>q.Id == carId).FirstOrDefault());
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Car> GetCarsByProductionYear(int year) {
            return _dbContext.Cars.Where(q => q.ProductionYear == year);
        }
    }
}

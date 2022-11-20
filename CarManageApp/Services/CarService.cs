using CarManageApp.DatabaseContext;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManageApp.Services {
    public class CarService {
        private AppDbcontext _dbContext;
        private ICarService _carService;

        public CarService(AppDbcontext appDbContext, ICarService carService) {
            _dbContext = appDbContext;
            _carService = carService;
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
    }
}

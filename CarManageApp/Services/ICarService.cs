using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManageApp.Services {
    public interface ICarService {
        Car GetCar(int carId);
        IEnumerable<Car> GetCars();
        IEnumerable<Car> GetCarsByProductionYear(int year);
        Car GetCarByRegisterNumber(string registerNumber);
        int GetCarCource(int carId);
        IEnumerable<string> GetModelsByMark(string mark);
        int AddCar(Car car);
        int RemoveCar(int carId);
    }
}

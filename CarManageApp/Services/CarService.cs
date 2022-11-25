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

        // konstruktor z wstrzykiwaniem zależności
        public CarService(AppDbcontext appDbContext) {
            _dbContext = appDbContext;
        }

        // zwraca obiekt Car, na podstawie id pojazdu
        public Car GetCar(int carId) {
            return _dbContext.Cars.Where(x => x.Id == carId).FirstOrDefault();
        }

        // metoda, która zwraca obiekt numeryczny, jako wszystkie pojazdy
        public IEnumerable<Car> GetCars() {
            return _dbContext.Cars;
        }

        // zwraca obiekt Car na podstawie numeru rejestracyjnego
        public Car GetCarByRegisterNumber(string registerNumber) {
            return _dbContext.Cars.Where(x => x.RegisterNumber == registerNumber).FirstOrDefault();
        }

        
        // zwraca przebiego pojazdu, na podstawie jego id
        public int GetCarCource(int carId) {
            return _dbContext.Cars.Where(x => x.Id == carId).Select(y => y.Course).FirstOrDefault();
        }

        // zwraca listę modele pojazdu na podstawie podanej marki
        public IEnumerable<string> GetModelsByMark(string mark) {
            return _dbContext.Cars.Where(x => x.Mark == mark).Select(y => y.Model).Distinct();
        }

        // dodanie pojazdu do bazy danych
        public int AddCar(Car car) {
            _dbContext.Cars.Add(car);
            return _dbContext.SaveChanges();
        }

        // usuwanie pojazdu z bazy danych
        public int RemoveCar(int carId) {
            _dbContext.Cars.Remove(_dbContext.Cars.Where(q=>q.Id == carId).FirstOrDefault());
            return _dbContext.SaveChanges();
        }

        // zwraca listę obiektów Car na podstawie roku produkcji
        public IEnumerable<Car> GetCarsByProductionYear(int year) {
            return _dbContext.Cars.Where(q => q.ProductionYear == year);
        }
    }
}

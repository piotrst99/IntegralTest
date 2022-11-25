using CarManageApp.DatabaseContext;
using CarManageApp.Services;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarManageApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase {
        private ICarService _carService;

        // konstruktor z wstrzykiwaniem zależności
        public CarController(ICarService carService) {
            _carService = carService;
        }

        // zwraca obiekt Car, na podstawie id pojazdu
        [HttpGet("GetCar")]
        public ActionResult<Car> GetCar(int carId) {
            return _carService.GetCar(carId);
        }

        // zwraca listę obiektów Car na podstawie roku produkcji
        [HttpGet("GetCarsByProductionYear")]
        public ActionResult<IEnumerable<Car>> GetCarsByProductionYear(int year) {
            return _carService.GetCarsByProductionYear(year).ToList();
        }

        // zwraca listę obiektów Car na podstawie roku produkcji
        [HttpGet("GetCarByRegisterNumber")]
        public ActionResult<Car> GetCarByRegisterNumber(string registerNumber) {
            return _carService.GetCarByRegisterNumber(registerNumber);
        }

        // zwraca przebiego pojazdu, na podstawie jego id
        [HttpGet("GetCarCource")]
        public ActionResult<int> GetCarByRegisterNumber(int carId) {
            return _carService.GetCarCource(carId);
        }

        // zwraca listę modele pojazdu na podstawie podanej marki
        [HttpGet("GetModelsByMark")]
        public ActionResult<IEnumerable<string>> GetModelsByMark(string mark) {
            return _carService.GetModelsByMark(mark).ToList();
        }

        // dodanie pojazdu do bazy danych
        [HttpPost("AddCar")]
        public ActionResult<int> AddCar(int carId) {
            return _carService.RemoveCar(carId);
        }

        [HttpDelete("RemoveCar")]
        public ActionResult<int> RemoveCar(int carId) {
            return _carService.RemoveCar(carId);
        }
    }
}

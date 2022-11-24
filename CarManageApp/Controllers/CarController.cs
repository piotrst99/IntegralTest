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

        public CarController(ICarService carService) {
            _carService = carService;
        }

        [HttpGet("GetCar")]
        public ActionResult<Car> GetCar(int carId) {
            return _carService.GetCar(carId);
        }

        [HttpGet("GetCarsByProductionYear")]
        public ActionResult<IEnumerable<Car>> GetCarsByProductionYear(int year) {
            return _carService.GetCarsByProductionYear(year).ToList();
        }

        [HttpGet("GetCarByRegisterNumber")]
        public ActionResult<Car> GetCarByRegisterNumber(string registerNumber) {
            return _carService.GetCarByRegisterNumber(registerNumber);
        }

        [HttpGet("GetCarCource")]
        public ActionResult<int> GetCarByRegisterNumber(int carId) {
            return _carService.GetCarCource(carId);
        }

        [HttpGet("GetModelsByMark")]
        public ActionResult<IEnumerable<string>> GetModelsByMark(string mark) {
            return _carService.GetModelsByMark(mark).ToList();
        }

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

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

// https://www.fearofoblivion.com/asp-net-core-integration-testing

namespace CarManageApp.Controllers {
    [Route("[controller]")]
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

        [HttpPost("AddCar")]
        public ActionResult<int> AddCar(Car car) {
            return _carService.AddCar(car);
        }

        [HttpDelete("RemoveCar")]
        public ActionResult<int> Remove(int carId) {
            return _carService.RemoveCar(carId);
        }
    }
}

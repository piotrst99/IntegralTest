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
        //private readonly ILogger<Car> _logger;
        //private readonly ICarService _carService;

        public CarController(
            //ILogger<Car> logger, 
            //ICarService carService
        ) {
            //_logger = logger;
            //_carService = carService;
        }

        [HttpGet("GetCar")]
        public ActionResult<Car> GetCar(int carId) {
            //return Ok(_carService.GetCar(carId));
            return Ok(null);
        }
    }
}

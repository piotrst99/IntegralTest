using CarManageApp.Services;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarManageApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CarRepairController : ControllerBase {
        private ICarRepairService _carRepairService;

        public CarRepairController(ICarRepairService carRepairService) {
            _carRepairService = carRepairService;
        }

        [HttpGet("GetCustomer")]
        public ActionResult<CarRepair> GetCarRepair(int repairId) {
            return _carRepairService.GetCarRepair(repairId);
        }

        [HttpGet("GetCarRepairsByRepairDate")]
        public ActionResult<IEnumerable<CarRepair>> GetCarRepairsByRepairDate(string date) {
            return _carRepairService.GetCarRepairsByRepairDate(date).ToList();
        }

        [HttpGet("GetCost")]
        public ActionResult<int> GetCost(int repairId) {
            return _carRepairService.GetCost(repairId);
        }

        [HttpGet("GetCarsByCustomerId")]
        public ActionResult<IEnumerable<Car>> GetCarsByCustomerId(int customerId) {
            return _carRepairService.GetCarsByCustomerId(customerId).ToList();
        }

        [HttpPost("AddCarRepair")]
        public ActionResult<int> AddCarRepair(CarRepair carRepair) {
            return _carRepairService.AddCarRepair(carRepair);
        }

        [HttpPut("UpdateCarRepair")]
        public ActionResult<int> UpdateCarRepair(CarRepair carRepair) {
            return _carRepairService.UpdateCarRepair(carRepair);
        }
    }
}

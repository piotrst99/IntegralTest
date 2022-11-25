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

        // konstruktor z wstrzykiwaniem zależności
        public CarRepairController(ICarRepairService carRepairService) {
            _carRepairService = carRepairService;
        }

        // pobranie danych naprawy na podstawie jego id
        [HttpGet("GetCarRepair")]
        public ActionResult<CarRepair> GetCarRepair(int repairId) {
            return _carRepairService.GetCarRepair(repairId);
        }

        // zwraca listę napraw w danym dniu
        [HttpGet("GetCarRepairsByRepairDate")]
        public ActionResult<IEnumerable<CarRepair>> GetCarRepairsByRepairDate(string date) {
            return _carRepairService.GetCarRepairsByRepairDate(date).ToList();
        }

        // zwraca koszt naprawy
        [HttpGet("GetCost")]
        public ActionResult<int> GetCost(int repairId) {
            return _carRepairService.GetCost(repairId);
        }

        // zwraca listę samochodów na podstawie id klienta
        [HttpGet("GetCarsByCustomerId")]
        public ActionResult<IEnumerable<Car>> GetCarsByCustomerId(int customerId) {
            return _carRepairService.GetCarsByCustomerId(customerId).ToList();
        }

        // dodanie danych do bazy dotyczącej naprawy pojazdu
        [HttpPost("AddCarRepair")]
        public ActionResult<int> AddCarRepair(CarRepair carRepair) {
            return _carRepairService.AddCarRepair(carRepair);
        }

        // aktualizacja danych dotyczącej naprawy
        [HttpPut("UpdateCarRepair")]
        public ActionResult<int> UpdateCarRepair(CarRepair carRepair) {
            return _carRepairService.UpdateCarRepair(carRepair);
        }
    }
}

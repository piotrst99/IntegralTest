using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarManageApp.Services {
    public interface ICarRepairService {
        CarRepair GetCarRepair(int repairId);
        IEnumerable<CarRepair> GetCarRepairsByRepairDate(string date);
        int GetCost(int repairId);
        IEnumerable<Car> GetCarsByCustomerId(int customerId);
        int AddCarRepair(CarRepair carRepair);
        int UpdateCarRepair(CarRepair carRepair);
    }
}

using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarManageApp.Services {
    public interface ICustomerService {
        Customer GetCustomer(int customerId);
        IEnumerable<Customer> GetCustomers();
        string GetEmail(string name, string surname);
        int AddCustomer(Customer customer);
        int RemoveCustomer(int customerId);
    }
}

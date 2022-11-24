using CarManageApp.DatabaseContext;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarManageApp.Services {
    public class CustomerService : ICustomerService {
        private AppDbcontext _dbContext;

        public CustomerService(AppDbcontext appDbcontext) {
            _dbContext = appDbcontext;
        }

        public int AddCustomer(Customer customer) {
            _dbContext.Customers.Add(customer);
            return _dbContext.SaveChanges();
        }

        public Customer GetCustomer(int customerId) {
            return _dbContext.Customers.FirstOrDefault(q => q.Id == customerId);
        }

        public IEnumerable<Customer> GetCustomers() {
            return _dbContext.Customers;
        }

        public string GetEmail(string name, string surname) {
            return _dbContext.Customers.FirstOrDefault(q => q.Name == name && q.Surname == surname)?.Email;
        }

        public int RemoveCustomer(int customerId) {
            _dbContext.Customers.Remove(_dbContext.Customers.FirstOrDefault(q=>q.Id == customerId));
            return _dbContext.SaveChanges();
        }
    }
}

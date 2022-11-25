using CarManageApp.DatabaseContext;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarManageApp.Services {
    public class CustomerService : ICustomerService {
        private AppDbcontext _dbContext;

        // konstruktor z wstrzykiwaniem zależności
        public CustomerService(AppDbcontext appDbcontext) {
            _dbContext = appDbcontext;
        }

        // dodanie klienta do bazy danych
        public int AddCustomer(Customer customer) {
            _dbContext.Customers.Add(customer);
            return _dbContext.SaveChanges();
        }

        //zwraca obiekt Customer, na podstawie jego id
        public Customer GetCustomer(int customerId) {
            return _dbContext.Customers.FirstOrDefault(q => q.Id == customerId);
        }

        // zwraca listę wszystkich klientów
        public IEnumerable<Customer> GetCustomers() {
            return _dbContext.Customers;
        }

        // zwraca adres email na podstawie imienia i nazwiska klienta
        public string GetEmail(string name, string surname) {
            return _dbContext.Customers.FirstOrDefault(q => q.Name == name && q.Surname == surname)?.Email;
        }

        // usuwanie klienta z bazy danych
        public int RemoveCustomer(int customerId) {
            _dbContext.Customers.Remove(_dbContext.Customers.FirstOrDefault(q=>q.Id == customerId));
            return _dbContext.SaveChanges();
        }
    }
}

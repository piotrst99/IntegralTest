using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CarManageApp.DatabaseContext;
using NUnit.Framework.Internal;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using CarManageApp.Services;

namespace IntegralTest {
    [TestFixture]
    public class CustomerIntegralTest {
        // tworzenie połączenia do bazy danych
        private static AppDbcontext _appDbContext = new AppDbcontext(
            options: new DbContextOptionsBuilder<AppDbcontext>()
                .UseSqlServer("Server=localhost; Initial Catalog=CarDatabase; Integrated Security=True;")
                .Options
            );
        private ICustomerService _customerService = new CustomerService(_appDbContext);

        // zwraca klienta z bazy danych - powinien zwrocic wartosc oraz null
        [Test]
        public void GetCustomerFromDatabase_GetCustomer_ShouldBeOk() {
            Customer customer = _customerService.GetCustomer(4);
            Assert.AreEqual(customer.Id, 4);
            Assert.AreNotEqual(customer, null);

            Customer customer2 = _customerService.GetCustomer(123);
            Assert.AreEqual(customer2, null);
        }

        // zwraca wiele klientow z bazy danych - powinien zwrocic liste oraz liczbe obiektow
        [Test]
        public void GetCustomersFromDatabase_GetCustomers_ShouldBeOk() {
            IEnumerable<Customer> customers = _customerService.GetCustomers();
            Assert.AreEqual(customers.Count(), 6);
        }

        // zwraca adres email z bazy danych - powinien zwrocic wartosc
        [Test]
        public void GetEmailFromDatabase_GetEmail_ShouldBeOk() {
            string customerEmail = _customerService.GetEmail("Jan", "Nowak");
            Assert.AreEqual(customerEmail, String.Empty);

            string customerEmail2 = _customerService.GetEmail("Piotr", "Staw");
            Assert.AreEqual(customerEmail2, "piotr.staw@gmail.com");

            string customerEmail3 = _customerService.GetEmail("Barbara", "Kozieńska");
            Assert.AreEqual(customerEmail3, null);
        }

        // dodanie obiektu klasy Customer do bazy danych - powinien zwrócic rekord z bazy danych
        [Test, Isolated]
        public void AddCustomerToDatabase_AddCustomer_ShouldBeOk() {
            Customer customer = new Customer {
                Name = "Karolina",
                Surname = "Hub",
                Address = "Łącko 323",
                Phone = " 543 278 876",
                Email = ""
            };

            int countOfCustomersBefore = _appDbContext.Customers.Count();
            Assert.AreEqual(countOfCustomersBefore, 6);
            _customerService.AddCustomer(customer);
            int countOfCustomersAfter = _appDbContext.Customers.Count();
            Assert.AreEqual(countOfCustomersAfter, 7);
        }

        // dodanie wielu obiektu klasy Customer do bazy danych - powinien zwrócic rekordy oraz ich liczbę z bazy danych
        [Test, Isolated]
        public void AddMoreCustomerToDatabase_AddCustomer_ShouldBeOk() {
            Customer customer = new Customer {
                Name = "Karolina",
                Surname = "Hub",
                Address = "Łącko 323",
                Phone = " 543 278 876",
                Email = ""
            };

            Customer customer2 = new Customer {
                Name = "Robert",
                Surname = "Olcha",
                Address = "ul. Wawel 12/3, 10-987 Kraków",
                Phone = " 542 687 478",
                Email = "robert.olcha@gmail.com"
            };

            int countOfCustomersBefore = _appDbContext.Customers.Count();
            Assert.AreEqual(countOfCustomersBefore, 6);
            _customerService.AddCustomer(customer);
            _customerService.AddCustomer(customer2);
            int countOfCustomersAfter = _appDbContext.Customers.Count();
            Assert.AreEqual(countOfCustomersAfter, 8);
        }

        // usuwa obiekt klasy Customer   z bazy danych - powinien zwrócic null z bazy danych
        [Test, Isolated]
        public void RemoveCustomerToDatabase_RemoveCustomer_ShouldBeOk() {
            int countOfCustomersBefore = _appDbContext.Customers.Count();
            Assert.AreEqual(countOfCustomersBefore, 6);
            
            _customerService.RemoveCustomer(5);

            int countOfCustomersAfter = _appDbContext.Customers.Count();
            Assert.AreEqual(countOfCustomersAfter, 5);

            Customer customer = _appDbContext.Customers.FirstOrDefault(q => q.Id == 5);
            Assert.AreEqual(customer, null);
        }

        // usuwa obiekty klasy Customer z bazy danych - powinien zwrócic null oraz wartosc z bazy danych
        [Test, Isolated]
        public void RemovemoreCustomerToDatabase_RemoveCustomer_ShouldBeOk() {
            int countOfCustomersBefore = _appDbContext.Customers.Count();
            Assert.AreEqual(countOfCustomersBefore, 6);

            _customerService.RemoveCustomer(5);
            _customerService.RemoveCustomer(1);
            _customerService.RemoveCustomer(6);

            int countOfCustomersAfter = _appDbContext.Customers.Count();
            Assert.AreEqual(countOfCustomersAfter, 3);
        }
    }
}

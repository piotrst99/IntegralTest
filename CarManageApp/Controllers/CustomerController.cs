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
    public class CustomerController : ControllerBase {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService) {
            _customerService = customerService;
        }

        [HttpGet("GetCustomer")]
        public ActionResult<Customer> GetCustomer(int customerId) {
            return _customerService.GetCustomer(customerId);
        }

        [HttpGet("GetCustomers")]
        public ActionResult<IEnumerable<Customer>> GetCustomers() {
            return _customerService.GetCustomers().ToList();
        }

        [HttpGet("GetEmail")]
        public ActionResult<string> GetEmail(string name, string surname) {
            return _customerService.GetEmail(name, surname);
        }

        [HttpPost("AddCustomer")]
        public ActionResult<int> AddCustomer(Customer customer) {
            return _customerService.AddCustomer(customer);
        }

        [HttpDelete("RemoveCustomer")]
        public ActionResult<int> RemoveCustomer(int customerId) {
            return _customerService.RemoveCustomer(customerId);
        }
    }
}

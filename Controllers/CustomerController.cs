using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace vanilla_angular.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController
    {
        private static List<Customer> CUSTOMER_LIST = new List<Customer>
        {
            new Customer(0, "Willy Wonker", 23.50m)
            , new Customer(1, "Dolores O'Riordan", 1211.10m)
            , new Customer(2, "Taliavar Ahmed", 33925.95m)
            , new Customer(3, "Raja Pochanapeddi", 99.00m)
            , new Customer(4, "Peter Rabbit", 44.50m)
        };

        [HttpGet]
        public JsonResult ListCustomers()
        {
            return new JsonResult(CUSTOMER_LIST);
        }

        [HttpPost]
        public IActionResult SaveCustomer([FromBody] PostCustomer customer)
        {
            if(customer == null || customer.Name == null) {
                return new BadRequestResult();
            }

            Customer created = new Customer(CUSTOMER_LIST.Count, customer.Name, customer.AccountBalance);
            CUSTOMER_LIST.Add(created);
            return new OkResult();
        }
    }

    public class Customer
    {
        public int Id { get; }
        public string Name { get; }
        public decimal AccountBalance { get; }
        public Customer(int id, string name, decimal accountBalance)
        {
            this.Id = id;
            this.Name = name;
            this.AccountBalance = accountBalance;
        }
    }

    public class PostCustomer
    {
        public string Name { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
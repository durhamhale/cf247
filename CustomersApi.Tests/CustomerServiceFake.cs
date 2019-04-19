using System;  
using System.Collections.Generic;
using System.Linq;
using CustomersApi.Contracts;
using CustomersApi.Models;

namespace CustomersApi.Tests
{
    class CustomerServiceFake : ICustomerService
    {
        private readonly List<Customer> _customers;

        public CustomerServiceFake()
        {
            _customers = new List<Customer>()
            {
                new Customer() { 
                    Id = "record1",
                    FirstName = "First 1", 
                    Surname = "Last 1", 
                    Email = "email1@domain.com", 
                    Password = "hash1" 
                },
                new Customer() { 
                    Id = "record2",
                    FirstName = "First 2", 
                    Surname = "Last 2", 
                    Email = "email2@domain.com", 
                    Password = "hash2" 
                },
                new Customer() { 
                    Id = "record3",
                    FirstName = "First 3", 
                    Surname = "Last 3", 
                    Email = "email3@domain.com", 
                    Password = "hash3" 
                }
            };
        }

        public List<Customer> Get()
        {
            return _customers;
        }

        public Customer Get(string id)
        {
            return _customers.Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public Customer Create(Customer customer)
        {
            customer.Id = "fakeId"; 
            _customers.Add(customer);
            return customer;
        }

        public void Update(string id, Customer updateCustomer)
        {
            var customer = _customers.First(a => a.Id == id);
            customer = updateCustomer;
        }

        public void Delete(string id)
        {
            var customer = _customers.First(a => a.Id == id);
            _customers.Remove(customer);
        }
    }
}

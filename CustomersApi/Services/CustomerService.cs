using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using CustomersApi.Contracts;
using CustomersApi.Models;

namespace CustomersApi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("datastore"));
            var database = client.GetDatabase("cf247TechTask");
            _customers = database.GetCollection<Customer>("customers");
        }

        public List<Customer> Get()
        {
            return _customers.Find(customer => true).ToList();
        }

        public Customer Get(string id)
        {
            return _customers.Find<Customer>(customer => customer.Id == id).FirstOrDefault();
        }

        public Customer Create(Customer customer)
        {
            _customers.InsertOne(customer);
            return customer;
        }

        public void Update(string id, Customer updateCustomer)
        {
            _customers.ReplaceOne(customer => customer.Id == id, updateCustomer);
        }

        public void Delete(string id)
        {
            _customers.DeleteOne(customer => customer.Id == id);
        }
    }
}

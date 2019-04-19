using System.Collections.Generic;
using CustomersApi.Models;

namespace CustomersApi.Contracts
{
    public interface ICustomerService
    {
        List<Customer> Get();
        Customer Get(string id);
        Customer Create(Customer customer);
        void Update(string id, Customer updateCustomer);
        void Delete(string id);
    }       
}

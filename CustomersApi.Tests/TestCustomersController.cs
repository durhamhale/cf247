using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using CustomersApi.Contracts;
using CustomersApi.Controllers;
using CustomersApi.Models;

namespace CustomersApi.Tests
{
    public class TestCustomersController
    {
        CustomersController _controller;
        ICustomerService _service;

        public TestCustomersController()
        {
            _service = new CustomerServiceFake();
            _controller = new CustomersController(_service);
        }

        [Fact]
        public void Get_ReturnsOkResult()
        {
            var response = _controller.Get();

            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public void Get_ReturnsAllItems()
        {
            var response = _controller.Get().Result as OkObjectResult;

            var items = Assert.IsType<List<Customer>>(response.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void Get_ExistingId_ReturnsOkResult()
        {
            var response = _controller.Get("record1");

            Assert.IsType<OkObjectResult>(response.Result);
        }

        [Fact]
        public void Get_ExistingId_ReturnsCustomer()
        {
            var testId = "record1";

            var response = _controller.Get(testId).Result as OkObjectResult;

            Assert.IsType<Customer>(response.Value);
            Assert.Equal(testId, (response.Value as Customer).Id);
        }

        [Fact]
        public void Get_UnknownId_ReturnsNotFoundResult()
        {
            var response = _controller.Get("missingrecord");

            Assert.IsType<NotFoundResult>(response.Result);
        }

        [Fact]
        public void Create_ValidObject_ReturnsCreatedAtRouteResult()
        {
            Customer testItem = new Customer() {
                FirstName = "First name",
                Surname = "Surname",
                Email = "email@domain.com",
                Password = "password123"
            };

            var response = _controller.Create(testItem).Result as CreatedAtRouteResult;

            Assert.IsType<CreatedAtRouteResult>(response);
        }

        [Fact]
        public void Create_ValidObject_ReturnsCustomer()
        {
            Customer testItem = new Customer() {
                FirstName = "First name",
                Surname = "Surname",
                Email = "email@domain.com",
                Password = "password123"
            };

            var response = _controller.Create(testItem).Result as CreatedAtRouteResult;
            var customer = response.Value as Customer;

            Assert.IsType<Customer>(customer);
            Assert.Equal(testItem.FirstName, customer.FirstName);
        }

        [Fact]
        public void Create_ValidObject_AddsOneCustomer()
        {
            Customer testItem = new Customer() {
                FirstName = "First name",
                Surname = "Surname",
                Email = "email@domain.com",
                Password = "password123"
            };

            var response = _controller.Create(testItem);

            Assert.Equal(4, _service.Get().Count());
        }

        [Fact]
        public void Update_NotExistingId_ReturnsNotFoundResult()
        {
            var testItem = new Customer() {};
            
            var response = _controller.Update("missingrecord", testItem);

            // Assert
            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void Update_ValidObject_ReturnsNoContentResult()
        {
            var testId = "record1";

            Customer testItem = _service.Get(testId);

            var response = _controller.Update(testId, testItem);

            Assert.IsType<NoContentResult>(response);
        }        

        [Fact]
        public void Update_ValidObject_UpdatesCustomer()
        {
            var testId = "record2";

            Customer testItem = _service.Get(testId);

            testItem.FirstName = "Updated first name";

            var response = _controller.Update(testId, testItem);

            Assert.Equal(testItem.FirstName, _service.Get("record2").FirstName);
        }

        [Fact]
        public void Delete_NotExistingId_ReturnsNotFoundResult()
        {
            var response = _controller.Delete("missingrecord");

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void Delete_ExistingId_ReturnsOkResult()
        {
            var response = _controller.Delete("record1");

            Assert.IsType<OkResult>(response);
        }

        [Fact]
        public void Delete_ExistingId_DeletesOneCustomer()
        {
            var response = _controller.Delete("record1");

            Assert.Equal(2, _service.Get().Count());
        }
    }
}
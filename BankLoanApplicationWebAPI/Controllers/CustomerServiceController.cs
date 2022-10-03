﻿using BankLoanApplicationWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Net.Http;
using System.Text;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankLoanApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerServiceController : ControllerBase
    {
        // GET: api/<CustomerServiceController>
        [HttpGet]
        public async Task<List<CustomerModel>?> GetAllCustomers()
        {
            string serviceUrl = "http://localhost:60306/WCFServices/CustomerService.svc/GetAllCustomers";
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var customerClient = new HttpClient();
            HttpResponseMessage respon = await customerClient.GetAsync(requestUri);
            string responJsonText = await respon.Content.ReadAsStringAsync();
            List<CustomerModel>? customers = JsonSerializer.Deserialize<List<CustomerModel>>(responJsonText);
            return customers;
        }

        // GET api/<CustomerServiceController>/5
        [HttpGet("{id}")]
        public async Task<CustomerModel?> GetCustomerById(string id)
        {
            string serviceUrl = "http://localhost:60306/WCFServices/CustomerService.svc/GetCustomerById/" + id;
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var customerClient = new HttpClient();
            HttpResponseMessage respon = await customerClient.GetAsync(requestUri);
            string responJsonText = await respon.Content.ReadAsStringAsync();
            CustomerModel? customer = JsonSerializer.Deserialize<CustomerModel?>(responJsonText);
            return customer;
        }

        // POST api/<CustomerServiceController>
        [HttpPost]
        public async Task PostCustomer(CustomerModel customer)
        {
            string serviceUrl = "http://localhost:60306/WCFServices/CustomerService.svc/AddCustomer";
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var customerClient = new HttpClient();
            var json = JsonSerializer.Serialize(customer);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await customerClient.PostAsync(requestUri, content);
        }

        // PUT api/<CustomerServiceController>/5
        [HttpPut("{id}")]
        public async Task PutCustomer(string id, CustomerModel customer)
        {
            string serviceUrl = "http://localhost:60306/WCFServices/CustomerService.svc/UpdatedCustomer/" + id;
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var customerClient = new HttpClient();
            var json = JsonSerializer.Serialize(customer);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await customerClient.PutAsync(requestUri, content);
        }

        // DELETE api/<CustomerServiceController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            string serviceUrl = "http://localhost:60306/WCFServices/CustomerService.svc/DeleteCustomer/" + id;
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var customerClient = new HttpClient();
            await customerClient.DeleteAsync(requestUri);
        }
    }
}

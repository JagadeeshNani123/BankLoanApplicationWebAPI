﻿using BankLoanApplicationWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankLoanApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        string loanServiceUrl = "http://localhost:60306/WCFServices/LoanService.svc/";
        [HttpGet]
        public async Task<List<LoanModel>?> GetAllLoans()
        {
            string serviceUrl = loanServiceUrl+ "GetAllLoans";
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var loanClient = new HttpClient();
            HttpResponseMessage respon = await loanClient.GetAsync(requestUri);
            string responJsonText = await respon.Content.ReadAsStringAsync();
            List<LoanModel>? loans = JsonSerializer.Deserialize<List<LoanModel>>(responJsonText);
            return loans;
        }

        // GET api/<CustomerServiceController>/5
        [HttpGet("{id}")]
        public async Task<LoanModel?> GetLoanById(string id)
        {
            string serviceUrl = loanServiceUrl + "GetLoanById/"+id;
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var loanClient = new HttpClient();
            HttpResponseMessage respon = await loanClient.GetAsync(requestUri);
            string responJsonText = await respon.Content.ReadAsStringAsync();
            LoanModel? loan = !string.IsNullOrEmpty(responJsonText)
                ? JsonSerializer.Deserialize<LoanModel?>(responJsonText) : new LoanModel();
            return loan;
        }

        // GET api/<CustomerServiceController>/5
        [HttpGet]
        [Route("GetAllLoansByCustomerId")]
        public async Task<List<LoanModel>?> GetAllLoansByCustomerId(string id)
        {
            var allLoans = GetAllLoans();
            List<LoanModel>? customerLoans = null;
            if(allLoans.Result!=null && allLoans.Result.Count!=0)
            {
                var customerId = new Guid(id);
                customerLoans = allLoans.Result.Where(all => all.CustomerId == customerId).ToList();
            }
            return customerLoans;
        }

        // POST api/<CustomerServiceController>
        [HttpPost]
        public async Task PostLoan(LoanModel loan)
        {
            string serviceUrl = loanServiceUrl + "AddLoan";
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var loanClient = new HttpClient();
            var json = JsonSerializer.Serialize(loan);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await loanClient.PostAsync(requestUri, content);
        }

        // PUT api/<CustomerServiceController>/5
        [HttpPut("{id}")]
        public async Task PutLoan(string id, LoanModel loan)
        {
            string serviceUrl = loanServiceUrl + "UpdateLoan/" + id;
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var loanClient = new HttpClient();
            var json = JsonSerializer.Serialize(loan);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await loanClient.PutAsync(requestUri, content);
        }

        // DELETE api/<CustomerServiceController>/5
        [HttpDelete("{id}")]
        public async Task DeleteLoan(string id)
        {
            string serviceUrl = loanServiceUrl + "DeleteLoan/" + id;
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var loanClient = new HttpClient();
            await loanClient.DeleteAsync(requestUri);
        }

        [HttpGet]
        [Route("GetOverAllLoanAmountOnExistingLoans")]
        public decimal GetOverAllLoanAmountOnExistingLoans(string id)
        {
            var allLons = GetAllLoans();
            var overAllLoanAmount = 0m;
            if (allLons.Result != null && allLons.Result.Count != 0)
            {
                overAllLoanAmount = allLons.Result.Sum(all => all.LoanAmount);
            }
            return overAllLoanAmount;
        }
    }
}

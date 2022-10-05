using BankLoanApplicationWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankLoanApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankDetailsController : ControllerBase
    {
        string BankDetailsserviceUrl = "http://localhost:60306/WCFServices/BankAccountDetailsService.svc/";
        [HttpGet]
        public async Task<List<BankDetails>?> GetAllBankDetails()
        {
            string serviceUrl = BankDetailsserviceUrl + "GetAllBankDetails";
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var loanClient = new HttpClient();
            HttpResponseMessage respon = await loanClient.GetAsync(requestUri);
            string responJsonText = await respon.Content.ReadAsStringAsync();
            List<BankDetails>? BankDetailss = JsonSerializer.Deserialize<List<BankDetails>>(responJsonText);
            return BankDetailss;
        }

        // GET api/<CustomerServiceController>/5
        [HttpGet("{id}")]
        public async Task<BankDetails?> GetBankDetailsById(string id)
        {
            string serviceUrl = BankDetailsserviceUrl + "GetBankDetailsById/" + id;
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var loanClient = new HttpClient();
            HttpResponseMessage respon = await loanClient.GetAsync(requestUri);
            string responJsonText = await respon.Content.ReadAsStringAsync();
            BankDetails? loan = !string.IsNullOrEmpty(responJsonText)
                ? JsonSerializer.Deserialize<BankDetails?>(responJsonText) : new BankDetails();
            return loan;
        }

        // POST api/<CustomerServiceController>
        [HttpPost]
        public async Task PostBankDetails(BankDetails loan)
        {
            string serviceUrl = BankDetailsserviceUrl + "AddBankDetails";
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var loanClient = new HttpClient();
            var json = JsonSerializer.Serialize(loan);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await loanClient.PostAsync(requestUri, content);
        }

        // PUT api/<CustomerServiceController>/5
        [HttpPut("{id}")]
        public async Task PutBankDetails(string id, BankDetails loan)
        {
            string serviceUrl = BankDetailsserviceUrl + "UpdateBankDetails/" + id;
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var customerClient = new HttpClient();
            var json = JsonSerializer.Serialize(loan);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await customerClient.PutAsync(requestUri, content);
        }

        // DELETE api/<CustomerServiceController>/5
        [HttpDelete("{id}")]
        public async Task DeleteBankDetails(string id)
        {
            string serviceUrl = BankDetailsserviceUrl + "DeleteBankDetails/" + id;
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var customerClient = new HttpClient();
            await customerClient.DeleteAsync(requestUri);
        }

        [HttpGet]
        [Route("GetOverAllLoanAmountOnExistingBankDetails")]
        public decimal GetOverAllBankDetailsAmountOnExistingBankDetails(string id)
        {
            var overAllLoanAmount = 0m;

            return overAllLoanAmount;
        }
    }
}


using BankLoanApplicationWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankLoanApplicationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanEMIController : ControllerBase
    {
        string LoanEMIserviceUrl = "http://localhost:60306/WCFServices/LoanEMIService.svc/";
        [HttpGet]
        public async Task<List<LoanEMIModel>?> GetAllLoanEMIs()
        {
            string serviceUrl = LoanEMIserviceUrl + "GetAllLoanEMIs";
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var loanClient = new HttpClient();
            HttpResponseMessage respon = await loanClient.GetAsync(requestUri);
            string responJsonText = await respon.Content.ReadAsStringAsync();
            List<LoanEMIModel>? LoanEMIs = JsonSerializer.Deserialize<List<LoanEMIModel>>(responJsonText);
            return LoanEMIs;
        }

        // GET api/<CustomerServiceController>/5
        [HttpGet("{id}")]
        public async Task<LoanEMIModel?> GetLoanEMIById(string id)
        {
            string serviceUrl = LoanEMIserviceUrl + "GetLoanEMIById/" + id;
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var loanClient = new HttpClient();
            HttpResponseMessage respon = await loanClient.GetAsync(requestUri);
            string responJsonText = await respon.Content.ReadAsStringAsync();
            LoanEMIModel? loan = !string.IsNullOrEmpty(responJsonText)
                ? JsonSerializer.Deserialize<LoanEMIModel?>(responJsonText) : new LoanEMIModel();
            return loan;
        }

        // POST api/<CustomerServiceController>
        [HttpPost]
        public async Task PostLoanEMI(LoanEMIModel loan)
        {
            string serviceUrl = LoanEMIserviceUrl + "AddLoanEMI";
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var loanClient = new HttpClient();
            var json = JsonSerializer.Serialize(loan);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await loanClient.PostAsync(requestUri, content);
        }

        // PUT api/<CustomerServiceController>/5
        [HttpPut("{id}")]
        public async Task PutLoanEMI(string id, LoanEMIModel loan)
        {
            string serviceUrl = LoanEMIserviceUrl + "UpdateLoanEMI/" + id;
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var loanEMIClient = new HttpClient();
            var json = JsonSerializer.Serialize(loan);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await loanEMIClient.PutAsync(requestUri, content);
        }

        // DELETE api/<CustomerServiceController>/5
        [HttpDelete("{id}")]
        public async Task DeleteLoanEMI(string id)
        {
            string serviceUrl = LoanEMIserviceUrl + "DeleteLoanEMI/" + id;
            Uri requestUri = new Uri(serviceUrl); //replace your Url  

            var loanEMIClient = new HttpClient();
            await loanEMIClient.DeleteAsync(requestUri);
        }

        [HttpGet]
        [Route("GetOverAllLoanAmountOnExistingLoanEMIs")]
        public decimal GetOverAllLoanEMIAmountOnExistingLoanEMIs(string id)
        {
            var overAllLoanAmount = 0m;
           
            return overAllLoanAmount;
        }
    }
}

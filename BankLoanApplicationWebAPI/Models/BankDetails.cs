namespace BankLoanApplicationWebAPI.Models
{
    public class BankDetails
    {
        public Guid BankId { get; set; }
        public Guid CustomerId { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
    }
}

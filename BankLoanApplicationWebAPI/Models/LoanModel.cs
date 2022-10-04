namespace BankLoanApplicationWebAPI.Models
{
    public class LoanModel
    {
        public Guid LoanId { get; set; }

        public Guid CustomerId { get; set; }

        public string LoanType { get; set; }

        public decimal LoanAmount { get; set; }

        public string LoanApprovedDate { get; set; }

        public int LoanTenure { get; set; }


        public bool IsActive { get; set; }
    }
}

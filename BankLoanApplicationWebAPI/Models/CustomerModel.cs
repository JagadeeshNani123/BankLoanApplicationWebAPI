namespace BankLoanApplicationWebAPI.Models
{
    public class CustomerModel
    {
        public Guid Id { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string EmailAddress { get; set; }


        public string Password { get; set; }


        public string EmploymentType { get; set; }

        public string MaritialStatus { get; set; }

        public decimal Income { get; set; }


        public string DateOfBirth { get; set; }


        public string AddressProof { get; set; }


        public string AddressProofNumber { get; set; }


        public string PanCardNumber { get; set; }


        public string PhoneNumber { get; set; }
    }
}

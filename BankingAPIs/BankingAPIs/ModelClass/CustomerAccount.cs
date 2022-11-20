using System.ComponentModel.DataAnnotations;

namespace BankingAPIs.ModelClass
{
    public class CustomerAccount
    {
       /* public CustomerAccount()
        {
            var AccountGenerated = Convert.ToString((long)Math.Floor(rand.NextDouble()
                * 9_000_000_000L + 1_000_000_000L));
        }*/
        public int Id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }   
        public Gender gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public double AccountBalance { get; set; }
        public string Password { get; set; }
        //public string ConfrimPassword { get; set; }
        [Key]
        public string AccountGenerated { get; set; }
        public AccountType accountType { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        Random rand = new Random();

    

        public enum AccountType
        {
            Savings,
            Current
        }

        public enum Gender
        {
            Male,
            Female
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace BankingAPIs.ModelClass
{
    public class CustomerAccount
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Genders { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int BVN { get; set; }
        public double AccountBalance { get; set; }
        public string Password { get; set; }
        public string AccountGenerated { get; set; }
        public AccountType AccountTypes { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public enum AccountType
        {
            Savings = 1,
            Current = 2
        }

        public enum Gender
        {
            Male = 1,
            Female = 2
        }
    }
}

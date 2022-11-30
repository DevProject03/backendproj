using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingAPIs.ModelClass
{
    public class CustomerAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }   
        public Gender gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public double AccountBalance { get; set; }
        public string Password { get; set; }
        public string AccountGenerated { get; set; }
        public AccountType accountType { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public enum AccountType
        {
            Savings=1,
            Current=2
        }

        public enum Gender
        {
            Male=1,
            Female=2
        }
    }
}

using System.ComponentModel.DataAnnotations;
using static BankingAPIs.ModelClass.CustomerAccount;

namespace BankingAPIs.ModelClass
{
    public class SignUp
    {
        
        public int Id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public DateTime CreatedDate { get; }
        public string phoneNumber { get; set; }
        public Gender gender { get; set; }
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage = "Mismatch of password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public AccountType accountType { get; set; }

        
    }

    
}

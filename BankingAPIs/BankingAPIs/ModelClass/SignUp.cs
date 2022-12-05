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
        [RegularExpression("(^(0)(7|8|9){1}(0|1){1}[0–9]{8}", ErrorMessage ="Invalid Phone Format")]
        public string PhoneNumber { get; set; }
        public Gender Genders { get; set; }
        [RegularExpression("[A-Za-z0-9]+@[a-z]+\\.[a-z]{2,3}", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Mismatch of password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public AccountType AccountTypes { get; set; }


    }


}

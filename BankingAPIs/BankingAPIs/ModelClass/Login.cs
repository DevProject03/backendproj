using System.ComponentModel.DataAnnotations;

namespace BankingAPIs.ModelClass
{
    public class Login
    {
        public int Id  { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}

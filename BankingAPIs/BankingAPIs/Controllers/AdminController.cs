using BankingAPIs.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BankingAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminLogin _adminlogin;

        public AdminController(IAdminLogin adminLogin)
        {
            _adminlogin = adminLogin;

        }
        [HttpPost("AdminLogin")]

        public IActionResult Login(string Email, string password)
        {
            var b = _adminlogin.Login(Email, password);

            if (b == null)
            {
                return NotFound("Invalid Email or Password");
            }

            return Ok(b);
        }
    }
}

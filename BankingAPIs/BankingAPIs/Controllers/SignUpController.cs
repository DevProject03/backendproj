using AutoMapper;
using BankingAPIs.DATA;
using BankingAPIs.Interface;
using BankingAPIs.ModelClass;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace BankingAPIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        
        private readonly ISignUp _signup;

        public SignUpController(ISignUp signUp)
        {
           
            _signup = signUp;
        }

        [HttpPost]

        public IActionResult CreateNewAccount(SignUp signup)
        {
            
            return Ok(_signup.Create(signup, signup.Password, signup.ConfirmPassword));

        }


    }
}

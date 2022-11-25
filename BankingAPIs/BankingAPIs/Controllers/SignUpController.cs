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
        //private DataBank _dbcontext;
        //private IMapper _mapper;
        private ISignUp _signup;
        Random rand = new Random();

        public SignUpController(ISignUp signUp)
        {
           
            _signup = signUp;
        }

        [HttpPost]

        public IActionResult CreateNewAccount(SignUp signup)
        {
            
            if ( signup == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(_signup.Create(signup, signup.Password, signup.ConfirmPassword));

        }


    }
}

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
        private IMapper _mapper;
        private ISignUp _signup;
        Random rand = new Random();

        public SignUpController(IMapper mapper, ISignUp signUp)
        {
            //_dbcontext = dataBank;
            _mapper = mapper;
            _signup = signUp;
        }

        [HttpPost]

        public ActionResult CreateNewAccount(SignUp signup)
        {
            //var e = new CustomerAccount();

            var d = _mapper.Map<CustomerAccount>(signup);

            var a = "029";

            var b = Convert.ToString((long)Math.Floor(rand.NextDouble()
                * 9_000_000L + 1_000_000L));

            d.AccountGenerated = Convert.ToString(a + b);

            d.DateCreated = DateTime.Now;
            d.DateUpdated = DateTime.Now;





            if (d == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(_signup.Create(signup, signup.Password, signup.ConfirmPassword));

            // _dbcontext.CustomerAccounts.Add(d);

            //return _bankData.AcoountDetails.ToArray();

            //return CreatedAtAction(nameof(GetDetailsbyId), new { id = acoountDetail.AccId }, results);


        }


    }
}

using AutoMapper;
using BankingAPIs.DATA;
using BankingAPIs.DTOs;
using BankingAPIs.Interface;
using BankingAPIs.ModelClass;
using BankingAPIs.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankingAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        private readonly ICustomerAccount _customerAccount;

       
       

        public AccountController(ICustomerAccount customerAccount)
        {
            
            _customerAccount = customerAccount;
            
            
        }

        [HttpGet("getAccountById")]
        public IActionResult GetAccountById(int Id)
        {
            var d = _customerAccount.GetAccountById(Id);

            if (d == null)
            {
                return BadRequest("Not Found");
            }

            return Ok(d);
        }

        [HttpGet("getAccountByName")]
        public IActionResult GetAccountByName(string Name)
        {
            var d = _customerAccount.GetAccountByName(Name);

            if (d == null)
            {
                return BadRequest("Not Found");
            }

            return Ok(d);
        }

        [HttpGet("getAccountByAccountNumber")]
        public IActionResult GetAccountByAccountNumber(string AccountNumber)
        {

            var d = _customerAccount.GetAccountByAccountNumber(AccountNumber);

            if (d == null)
            {
                return NotFound("Not Found");
            }


            return Ok(d);
        }

        [HttpGet("getDetails")]

        public IActionResult GetDetails()
        {
            var b = _customerAccount.GetAccounts();
            return Ok(b);

        }

        [HttpGet("Search")]

        public ActionResult<IEnumerable<CustomerAccount>> Search(string SearchQuery)
        {
            var b =  _customerAccount.SearchAccounts(SearchQuery);

            if (b == null)
            {
                return BadRequest("Not Found");
            }

            return Ok(b);
        }

        
        [HttpDelete("DeleteCustomer")]

        public ActionResult DeleteCustomer(string AccountNumber)
        {
            CustomerAccount acc = _customerAccount.GetAccountByAccountNumber(AccountNumber);

            if (acc == null)
            {
                
                return NotFound("Not Found");

            }

            return NoContent();

        }

        [HttpPost("Login")]

        public IActionResult Login(string Email, string password)
        {
            var b = _customerAccount.Login(Email, password);

            if (b == null)
            {
                return NotFound("Invalid Email or Password");
            }

            return Ok(b);
        }


        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer(AccountDto accountDto, string AccountNumber)
        {
            var acc = _customerAccount.GetAccountByAccountNumber(AccountNumber);
           
            return acc != null ? Ok(_customerAccount.UpdateCustomer(AccountNumber, accountDto)) : NotFound("Not Found");
        }

    }
}
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
        
        private ICustomerAccount _customerAccount;

        private IMapper _mapper;
        private Account_Repo _account_repo;

        public AccountController(IMapper mapper, ICustomerAccount customerAccount)
        {
            
            _customerAccount = customerAccount;
            mapper = mapper;
            
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
                return BadRequest("Not Found");
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

        public async Task<ActionResult<IEnumerable<CustomerAccount>>> Search(string SearchQuery)
        {
            var b =  _customerAccount.SearchAccounts(SearchQuery);

            if (b == null)
            {
                return BadRequest("Not Found");
            }

            return Ok(b);
        }

        /*[HttpPost("Create")]
      
            /*var newaccounts = new CustomerAccount
            {
                FristName = newaccount.FristName,
                LastName = newaccount.LastName,
                Email = newaccount.Email,
                Password = newaccount.Password,
                PhoneNumber = newaccount.PhoneNumber,
                AccountBalance = 0.00,
                //AccountGenerated = CustomerAccount.AccountGenerated,
                accountType = newaccount.accountType,
                DateCreated = DateTime.Now,
                DateOfBirth = newaccount.DateOfBirth,
                Gender = newaccount.Gender,



            };

        }*/

        [HttpDelete("DeleteCustomer")]

        public ActionResult DeleteCustomer(string AccountNumber)
        {
            var acc = _customerAccount.GetAccountByAccountNumber(AccountNumber);

            if (acc != null)
            {
                return NoContent();
                
            }

            return NotFound("Not Found");

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
        public IActionResult UpdateCustomer(AccountDTO accountDto, string AccountNumber)
        {
            var acc = _customerAccount.GetAccountByAccountNumber(AccountNumber);

            AccountDTO accountDTO = new AccountDTO()
            {
                Email = acc.Email,
                Password = acc.Password,
            
            };


            if (accountDTO == null)
            {
                return NotFound("Not Found");
            }

            return Ok(_customerAccount.UpdateCustomer(accountDTO, accountDto));

        }


    }
}
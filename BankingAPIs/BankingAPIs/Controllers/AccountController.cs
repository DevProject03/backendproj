using BankingAPIs.DTOs;
using BankingAPIs.Interface;
using BankingAPIs.ModelClass;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                var d = _customerAccount.GetAccountById(Id);

                if (d == null)
                {
                    return NotFound("Not Found");
                }

                return Ok(d);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("getAccountByName")]
        public IActionResult GetAccountByName(string Name)
        {
            try
            {
                var d = _customerAccount.GetAccountByName(Name);

                if (d == null)
                {
                    return NotFound("Not Found");
                }

                return Ok(d);
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }

        }

        [HttpGet("getAccountByAccountNumber")]
        public IActionResult GetAccountByAccountNumber(string AccountNumber)
        {
            try
            {
                var d = _customerAccount.GetAccountByAccountNumber(AccountNumber);

                if (d == null)
                {
                    return NotFound("Not Found");
                }


                return Ok(d);
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }


        }

        [HttpGet("getDetails")]

        public IActionResult GetDetails()
        {
            try
            {
                var b = _customerAccount.GetAccounts();
                return Ok(b);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        [HttpGet("Search")]

        public ActionResult<IEnumerable<CustomerAccount>> Search(string SearchQuery)
        {
            try
            {
                var b = _customerAccount.SearchAccounts(SearchQuery);

                if (b == null)
                {
                    return BadRequest("Not Found");
                }

                return Ok(b);
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }

        }


        [HttpDelete("DeleteCustomer")]

        public ActionResult DeleteCustomer(string AccountNumber)
        {
            try
            {
                var acc = _customerAccount.GetAccountByAccountNumber(AccountNumber);

                _customerAccount.DeleteCustomer(acc.Id);

                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }


        }

        [HttpPost("Login")]

        public IActionResult Login(LoginDTO login)
        {
            try
            {
                var b = _customerAccount.Login(login.Email, login.Password);

                if (b == null)
                {
                    return NotFound("Invalid Email or Password");
                }

                return Ok(b);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer(AccountDto accountDto, string AccountNumber)
        {
            try
            {
                var acc = _customerAccount.GetAccountByAccountNumber(AccountNumber);
                try
                {
                    return acc != null ? Ok(_customerAccount.UpdateCustomer(AccountNumber, accountDto)) : NotFound("Not Found");
                }
                catch (Exception ex)
                {

                    return NotFound(ex.Message);
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }



        }

    }
}
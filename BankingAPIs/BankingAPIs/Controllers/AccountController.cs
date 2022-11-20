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
        private DataBank _dbcontext;
        private ICustomerAccount _customerAccount;

        private IMapper _mapper;
        private Account_Repo _account_repo;

        public AccountController(DataBank Bankdata, IMapper mapper, ICustomerAccount customerAccount)
        {
            _dbcontext = Bankdata;
            _customerAccount = customerAccount;
            mapper = mapper;
            //_account_repo = account_Repo;
        }

        [HttpGet("getAccountById")]
        public ActionResult GetAccountById(int Id)
        {

            var d = _dbcontext.CustomerAccounts.Where(x => x.Id == Id).FirstOrDefault();

            if (d == null)
            {
                return BadRequest("Not Found");
            }


            return Ok(d);
        }

        [HttpGet("getAccountByName")]
        public ActionResult GetAccountByName(string Name)
        {

            var d = _dbcontext.CustomerAccounts.Where(x => x.FristName == Name).FirstOrDefault();

            if (d == null)
            {
                return BadRequest("Not Found");
            }


            return Ok(d);
        }

        [HttpGet("getAccountByAccountNumber")]
        public ActionResult GetAccountByAccountNumber(string AccountNumber)
        {

            var d = _dbcontext.CustomerAccounts.Where(x => x.AccountGenerated == AccountNumber)
                .FirstOrDefault();

            if (d == null)
            {
                return BadRequest("Not Found");
            }


            return Ok(d);
        }
        [HttpGet("getDetails")]

        public async Task<ActionResult<IEnumerable<CustomerAccount>>> GetDetails()
        {

            return _dbcontext.CustomerAccounts.ToArray();

        }

        [HttpGet("Search")]

        public async Task<ActionResult<IEnumerable<CustomerAccount>>> Search(string SearchQuery)
        {
            var b = _customerAccount.SearchAccounts(SearchQuery);

            if (b == null)
            {
                return BadRequest("Not Found");
            }

            return Ok(b);
        }

        /*[HttpPost("Create")]
        public ActionResult Create(CustomerAccount newacc, string Password)
        {
            if(string.IsNullOrWhiteSpace(Password))
                    throw new ArgumentNullException("Password cannot be empty");

            if (_dbcontext.CustomerAccounts.Any(x => x.Email == newacc.Email))
                throw new ApplicationException("A user with thiss email exists");

            if (_dbcontext.CustomerAccounts.Any(x => x.PhoneNumber == newacc.PhoneNumber))
                throw new ApplicationException("A user with thiss email exists");
            //var newCustomer = _account_repo.Create(newaccount, Password, ConfirmPassword);

            //var accnt = _mapper.Map<newaccount>(newCustomer);

            //return Ok(newCustomer);
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

            _dbcontext.CustomerAccounts.Add(newacc);
            _dbcontext.SaveChanges();

            //return Ok(_account_repo.Create(newacc, newacc.Password));
            return Ok();
        }*/

        [HttpDelete("DeleteCustomer")]

        public ActionResult DeleteCustomer(string AccountNumber)
        {
           var acc = _customerAccount.GetAccountByAccountNumber(AccountNumber);

            if (acc == null)
            {
                return BadRequest("Not Found");
            }

            _dbcontext.CustomerAccounts.Remove(acc);

           // _customerAccount.;

            _dbcontext.SaveChanges();
            
            return NoContent();

        }

        [HttpPost("Login")]

        public ActionResult Login (string Email, string password)
        {
            var b = _customerAccount.Login(Email, password);

            if (b == null)
            {
                return BadRequest("Invalid Email or Password");
            }

            return Ok(b);
        }


        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer(AccountDTO accountDto, string AccountNumber)
        {
            var acc = _customerAccount.GetAccountByAccountNumber(AccountNumber);

            //var d = _mapper.Map<AccountDTO>(acc);
           // accountDto.Email = acc.Email;
             //accountDto.Password = acc.Password;

            AccountDTO accountDTO = new AccountDTO() 
            { 
                Email = acc.Email,
                Password = acc.Password,
                //DateUpdated = DateTime.Now()
            };

           
            //AccountDTO s = _mapper.Map<CustomerAccount, AccountDTO>(acc);  

            if (accountDTO == null)
            {
                return BadRequest("Not Found");
            }

            

            //return Ok(_customerAccount.UpdateCustomer(d));

            return Ok(_customerAccount.UpdateCustomer(accountDTO, accountDto));

        }


    }
}

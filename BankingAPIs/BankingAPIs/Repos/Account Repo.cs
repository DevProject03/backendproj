using AutoMapper;
using BankingAPIs.DATA;
using BankingAPIs.DTOs;
using BankingAPIs.Interface;
using BankingAPIs.ModelClass;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using System.Xml.Linq;

namespace BankingAPIs.Repos
{
    public class Account_Repo : ICustomerAccount
    {
        private readonly DataBank _dbcontext;
        private readonly IMapper _mapper;

        public Account_Repo(DataBank Bankdata, IMapper mapper)
        {
           _dbcontext = Bankdata;
            _mapper = mapper;
        }

       /* public CustomerAccount Create(CustomerAccount newaccount, string Password, string ConfirmPassword)
        {
            
                if (string.IsNullOrWhiteSpace(Password) && string.IsNullOrWhiteSpace(ConfirmPassword))
                    throw new ArgumentNullException("Password cannot be empty");

                if (_dbcontext.CustomerAccounts.Any(x => x.Email == newaccount.Email))
                    throw new ApplicationException("A user with thiss email exists");

                if (_dbcontext.CustomerAccounts.Any(x => x.PhoneNumber == newaccount.PhoneNumber))
                    throw new ApplicationException("A user with thiss email exists");

            var newaccounts = new CustomerAccount
            {
                FristName = newaccount.FristName,
                LastName = newaccount.LastName,
                Email = newaccount.Email,
                Password = newaccount.Password,
                PhoneNumber = newaccount.PhoneNumber,
                AccountBalance = 0.00,
                AccountGenerated = newaccount.AccountGenerated,
                accountType = newaccount.accountType,
                DateCreated = DateTime.Now,
                DateOfBirth = newaccount.DateOfBirth,
                Gender = newaccount.Gender,



            };

            _dbcontext.CustomerAccounts.Add(newaccounts);
                _dbcontext.SaveChanges();

                return newaccounts;
            
        }
       */
        public CustomerAccount Create(CustomerAccount newacc, string Password)
        {
            _dbcontext.CustomerAccounts.Add(newacc);


            _dbcontext.SaveChanges();

            return newacc;
        }

        public void DeleteCustomer(string AccountNumber)
        {
            var account = _dbcontext.CustomerAccounts.Find(AccountNumber);
            if (account != null)
            {
                _dbcontext.CustomerAccounts.Remove(account);

                _dbcontext.SaveChanges();
            }
        }

        public CustomerAccount GetAccount(string Name)
        {
            var account = _dbcontext.CustomerAccounts.Where(x => x.LastName == Name).FirstOrDefault();
            return account;
        }

        public CustomerAccount GetAccountByAccountNumber(string AccountNumber)
        {
            var account = _dbcontext.CustomerAccounts.Where(x => x.AccountGenerated == AccountNumber).FirstOrDefault();
            return account;
        }

        

        public CustomerAccount GetAccountById(int Id)
        {
            var account = _dbcontext.CustomerAccounts.Where(x => x.Id == Id).FirstOrDefault();
            return account;
        }

        public CustomerAccount GetAccountByName(string Name)
        {
            var account = _dbcontext.CustomerAccounts.Where(x => x.FristName == Name).FirstOrDefault();
            return account;
        }

        public IEnumerable<CustomerAccount> GetAccounts()
        {
            return _dbcontext.CustomerAccounts.ToArray();
        }

        public IEnumerable<CustomerAccount> SearchAccounts(string SearchQuery)
        {
            IQueryable<CustomerAccount> customerAccounts1 = _dbcontext.CustomerAccounts;
           
            if (string.IsNullOrEmpty(SearchQuery))
            {
                return GetAccounts();
            }

            
            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                SearchQuery = SearchQuery.Trim();
                customerAccounts1 = customerAccounts1.Where(a => a.FristName.Contains(SearchQuery)
                || a.LastName.Contains(SearchQuery)|| a.Email.Contains(SearchQuery)|| a.AccountGenerated == SearchQuery);
            }

            return customerAccounts1.ToList();
        }

        public CustomerAccount Login(string Email, string password)
        {
            var user = _dbcontext.CustomerAccounts.Where(x => x.Email == Email).FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            bool ValidPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!ValidPassword)
            {
                return null;
            }


            return user;
        }

        public CustomerAccount UpdateCustomer(AccountDTO customer, AccountDTO NewUpdate)
        {
            var accountToBeUpdated = _dbcontext.CustomerAccounts.Where(x => x.Email == customer.Email).FirstOrDefault();
            if (accountToBeUpdated == null) throw new ApplicationException("Account not found");

            if (NewUpdate.Oldpassword != accountToBeUpdated.Password) throw new ApplicationException("Wrong Old password");
            //so we have a match

            if (!string.IsNullOrWhiteSpace(NewUpdate.Email) && NewUpdate.Email != accountToBeUpdated.Email)
            {
                //throw error because email passeed doesn't matc wiith
                if (_dbcontext.CustomerAccounts.Any(x => x.Email == NewUpdate.Email)) 
                    throw new ApplicationException("Email " + NewUpdate.Email + " has been taken");
                accountToBeUpdated.Email = NewUpdate.Email;
            }

            if (!string.IsNullOrWhiteSpace(NewUpdate.PhoneNumber) && NewUpdate.PhoneNumber != accountToBeUpdated.PhoneNumber)
            {
                //throw error because email passeed doesn't matc wiith
                if (_dbcontext.CustomerAccounts.Any(x => x.PhoneNumber == NewUpdate.PhoneNumber))
                    throw new ApplicationException("PhoneNumber " + NewUpdate.PhoneNumber + " has been taken");

                accountToBeUpdated.PhoneNumber = NewUpdate.PhoneNumber;
                

            }

           if (!string.IsNullOrWhiteSpace(NewUpdate.PhoneNumber))
            {
                accountToBeUpdated.Password = NewUpdate.Password;
            }


            accountToBeUpdated.DateUpdated = DateTime.Now;
            _dbcontext.CustomerAccounts.Update(accountToBeUpdated);
            _dbcontext.SaveChanges();

            return accountToBeUpdated;


        }

        
    }
}

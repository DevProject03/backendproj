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
            var accounts = _dbcontext.CustomerAccounts.ToArray();

            return accounts;

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
                customerAccounts1 = customerAccounts1.Where(a => a.Email.Contains(SearchQuery) || a.AccountGenerated == SearchQuery);
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

            bool ValidPassword = BCrypt.Net.BCrypt.Verify(NewUpdate.Oldpassword, accountToBeUpdated.Password);

            if (!ValidPassword) throw new ApplicationException("Wrong Old password");
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
                accountToBeUpdated.Password = BCrypt.Net.BCrypt.HashPassword(NewUpdate.Password);

            }


            accountToBeUpdated.DateUpdated = DateTime.Now;
            _dbcontext.CustomerAccounts.Update(accountToBeUpdated);
            _dbcontext.SaveChanges();

            return accountToBeUpdated;


        }


    }
}

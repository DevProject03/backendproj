using AutoMapper;
using BankingAPIs.DATA;
using BankingAPIs.Interface;
using BankingAPIs.ModelClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Security.Principal;

namespace BankingAPIs.Repos
{
    public class Signup : ISignUp
    {
        private readonly DataBank _dbcontext;
        private readonly IMapper _mapper;
        

        public Signup(DataBank dataBank, IMapper mapper )
        {
            _dbcontext = dataBank;
            _mapper = mapper;
        }

        

        public SignUp Create(SignUp newaccount, string Password, string ConfirmPassword)
        {
            if (string.IsNullOrWhiteSpace(Password) && string.IsNullOrWhiteSpace(ConfirmPassword))
                throw new ArgumentNullException("Password cannot be empty");

            if (_dbcontext.CustomerAccounts.Any(x => x.Email == newaccount.Email))
                throw (new ApplicationException("A user with this email exists"));

            if (_dbcontext.CustomerAccounts.Any(x => x.PhoneNumber == newaccount.phoneNumber))
                throw (new ApplicationException("A user with this phoneNumber exists"));

            newaccount.Password = BCrypt.Net.BCrypt.HashPassword(newaccount.Password);

           newaccount.ConfirmPassword = BCrypt.Net.BCrypt.HashPassword(newaccount.ConfirmPassword);

            _dbcontext.SignUps.Add(newaccount);

            var d = _mapper.Map<CustomerAccount>(newaccount);

            var accountNumber = new AccountNumber();

            d.AccountGenerated = accountNumber.AccountGenerated;

            d.DateCreated = DateTime.Now;
            d.DateUpdated = DateTime.Now;

            _dbcontext.CustomerAccounts.Add(d);

            _dbcontext.SaveChanges();

           
            return newaccount;
        }
    }
}

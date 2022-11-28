using AutoMapper;
using BankingAPIs.DTOs;
using BankingAPIs.Interface;
using BankingAPIs.ModelClass;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingAPIs.Test
{
    public class FakeRepo : ICustomerAccount
    {
        private readonly List<CustomerAccount> _shoppingCart;
        private readonly IMapper _mapper;

        public FakeRepo(IMapper mapper, List<CustomerAccount> _shoppingCart)
        {

            _mapper = mapper;
            List<CustomerAccount> ShoppingCart = new List<CustomerAccount>()
            {
                new CustomerAccount() { FristName = "Lopez",
            LastName = "Sam",
            Email = "Samuel@gmail.com",
            Password = "Anu",
            PhoneNumber = "12344",
            AccountBalance = 0,
            AccountGenerated = "0291234567",
            //accountType = CustomerAccount.AccountType,
            DateCreated = DateTime.Now,
            DateOfBirth = DateTime.Now },

                new CustomerAccount() { FristName = "Lopez",
            LastName = "Sam",
            Email = "Samuel@gmail.com",
            Password = "Anu",
            PhoneNumber = "12344",
            AccountBalance = 0,
            AccountGenerated = "0291234567",
            //accountType = CustomerAccount.AccountType,
            DateCreated = DateTime.Now,
            DateOfBirth = DateTime.Now, },


                new CustomerAccount() { FristName = "Lopez",
            LastName = "Sam",
            Email = "Samuel@gmail.com",
            Password = "Anu",
            PhoneNumber = "12344",
            AccountBalance = 0,
            AccountGenerated = "0291234567",
            //accountType = CustomerAccount.AccountType,
            DateCreated = DateTime.Now,
            DateOfBirth = DateTime.Now, }
            };
        }

        public CustomerAccount Create(CustomerAccount newacc, string Password)
        {
            _shoppingCart.Add(newacc);

            return newacc;
        }

        public void DeleteCustomer(string AcountNumber)
        {
            var acc = _shoppingCart.Where(a => a.AccountGenerated == AcountNumber).FirstOrDefault();

            if (acc != null)
            {
                _shoppingCart.Remove(acc);

            }
        }

        public CustomerAccount GetAccountByAccountNumber(string AccountNumber)
        {
            throw new NotImplementedException();
        }

        public CustomerAccount GetAccountById(int Id)
        {
            var d = _shoppingCart.Where(x => x.Id == Id).FirstOrDefault();
            return d;

        }

        public CustomerAccount GetAccountByName(string Name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerAccount> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public CustomerAccount Login(string Email, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerAccount> SearchAccounts(string SearchQuery)
        {
            throw new NotImplementedException();
        }

        public CustomerAccount UpdateCustomer(string AccountNumber, AccountDTO NewUpdate)
        {
            throw new NotImplementedException();
        }
    }


}

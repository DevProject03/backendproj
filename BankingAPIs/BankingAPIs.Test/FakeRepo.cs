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
        

        public FakeRepo()
        {

            
            
        }

        private readonly List<CustomerAccount> customerlist = new List<CustomerAccount>()
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

        public CustomerAccount Create(CustomerAccount newacc, string Password)
        {
            customerlist.Add(newacc);

            return newacc;
        }

        public void DeleteCustomer(string AcountNumber)
        {
            var acc = customerlist.FirstOrDefault(a => a.AccountGenerated == AcountNumber);

            if (acc != null)
            {
                customerlist.Remove(acc);

            }
        }

        public CustomerAccount GetAccountByAccountNumber(string AccountNumber)
        {
            throw new NotImplementedException();
        }

        public CustomerAccount GetAccountById(int Id)
        {
            var d = customerlist.FirstOrDefault(x => x.Id == Id);
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

        public CustomerAccount UpdateCustomer(string AccountNumber, AccountDto NewUpdate)
        {
            throw new NotImplementedException();
        }
    }


}

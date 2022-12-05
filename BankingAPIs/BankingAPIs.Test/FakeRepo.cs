using BankingAPIs.DTOs;
using BankingAPIs.Interface;
using BankingAPIs.ModelClass;

namespace BankingAPIs.Test
{
    public class FakeRepo : ICustomerAccount
    {


        public FakeRepo()
        {



        }

        private readonly List<CustomerAccount> customerlist = new List<CustomerAccount>()
            {
                new CustomerAccount() { FirstName = "Lopez",
            LastName = "Sam",
            Email = "Samuel@gmail.com",
            Password = "Anu",
            PhoneNumber = "12344",
            AccountBalance = 0,
            AccountGenerated = "0291234567",
            //accountType = CustomerAccount.AccountType,
            DateCreated = DateTime.Now,
            DateOfBirth = DateTime.Now },

                new CustomerAccount() { FirstName = "Lopez",
            LastName = "Sam",
            Email = "Samuel@gmail.com",
            Password = "Anu",
            PhoneNumber = "12344",
            AccountBalance = 0,
            AccountGenerated = "0291234567",
            //accountType = CustomerAccount.AccountType,
            DateCreated = DateTime.Now,
            DateOfBirth = DateTime.Now, },


                new CustomerAccount() { FirstName = "Lopez",
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

        public void DeleteCustomer(int Id)
        {
            var acc = customerlist.FirstOrDefault(a => a.Id == Id);

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

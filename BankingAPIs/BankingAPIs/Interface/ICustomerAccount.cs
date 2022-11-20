using BankingAPIs.DTOs;
using BankingAPIs.ModelClass;
using System.Collections.Generic;

namespace BankingAPIs.Interface
{
    public interface ICustomerAccount
    {
        //CustomerAccount Login (string Email, string password);   
        // Method that the repo will create

         CustomerAccount Create(CustomerAccount newacc, string Password);
        IEnumerable<CustomerAccount> GetAccounts();

        IEnumerable<CustomerAccount> SearchAccounts(string SearchQuery);
        CustomerAccount UpdateCustomer(AccountDTO customer, AccountDTO NewUpdate);
        CustomerAccount Login(string Email, string password);
        void DeleteCustomer(string AcountNumber);
        //CustomerAccount Create(CustomerAccount customerAccount, string Password);    
        CustomerAccount GetAccountById(int Id);
        CustomerAccount GetAccountByName(string Name);
        CustomerAccount GetAccountByAccountNumber(string AccountNumber);
    }
}

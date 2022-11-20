using BankingAPIs.Interface;
using BankingAPIs.ModelClass;

namespace BankingAPIs.Repos
{
    public class Admin : IAdminLogin
    {
        public CustomerAccount Create(CustomerAccount customerAccount, string Password)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(CustomerAccount customer)
        {
            throw new NotImplementedException();
        }

        public CustomerAccount GetAccountByAccountNumber(string AccountNumber)
        {
            throw new NotImplementedException();
        }

        public CustomerAccount GetAccountById(int Id)
        {
            throw new NotImplementedException();
        }

        public CustomerAccount GetAccountByName(string Name)
        {
            throw new NotImplementedException();
        }

        public ICollection<CustomerAccount> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public AdminLogin Login(string Email, string password)
        {
            throw new NotImplementedException();
        }

        public CustomerAccount Search(string query)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(CustomerAccount customer)
        {
            throw new NotImplementedException();
        }
    }
}

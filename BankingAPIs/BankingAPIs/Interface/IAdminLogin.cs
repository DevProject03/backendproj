using BankingAPIs.ModelClass;

namespace BankingAPIs.Interface
{
    public interface IAdminLogin
    {
        AdminLogin Login(string Email, string password);
        // Method that the repo will create
        ICollection<CustomerAccount> GetAccounts();
        void UpdateCustomer(CustomerAccount customer);
        void DeleteCustomer(CustomerAccount customer);
        CustomerAccount Search(string query);
        CustomerAccount Create(CustomerAccount customerAccount, string Password);
        CustomerAccount GetAccountById(int Id);
        CustomerAccount GetAccountByName(string Name);
        CustomerAccount GetAccountByAccountNumber(string AccountNumber);
    }
}

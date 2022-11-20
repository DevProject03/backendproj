using BankingAPIs.ModelClass;
using Microsoft.EntityFrameworkCore;

namespace BankingAPIs.DATA
{
    public class DataBank : DbContext
    {
        public DataBank(DbContextOptions<DataBank> options) :
            base(options)
        {

        }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<SignUp> SignUps { get; set; }
        public DbSet<Transcation> Transcations { get; set; }

    }
}

using AutoMapper;
using BankingAPIs.DATA;
using BankingAPIs.Interface;
using BankingAPIs.ModelClass;
using Microsoft.EntityFrameworkCore;

namespace BankingAPIs.Repos
{
    public class Admin : IAdminLogin
    {
        private DataBank _dbcontext;
        private IMapper _mapper;

        public Admin(DataBank Bankdata, IMapper mapper)
        {
            _dbcontext = Bankdata;
            _mapper = mapper;

        }
      

        public AdminLogin Login(string Email, string password)
        {
            var user = _dbcontext.AdminLogins.Where(x => x.Email == Email).FirstOrDefault();

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

       
    }
}

using AutoMapper;
using BankingAPIs.DATA;
using BankingAPIs.Interface;

namespace BankingAPIs.Repos
{
    public class Login : ILogin
    {
        public ModelClass.Login Authenticate(string Email, string password)
        {
            throw new NotImplementedException();
        }
    }
       /* private DataBank _databank;

        public Login(DataBank dataBank, IMapper mapper)
        {
            _databank = dataBank;
        }
       */
      /* ModelClass.Login ILogin.Authenticate(string Email, string password)
        {
            var user = _databank.CustomerAccounts.Where(x => x.Email == Email).FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            if (user.Password != password)
            {
                return null;
            }


            return ;
        }
    }*/
}

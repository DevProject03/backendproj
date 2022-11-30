using AutoMapper;
using BankingAPIs.ModelClass;
using BankingAPIs.DTOs;

namespace BankingAPIs.Helper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerAccount, AccountDto >();

            CreateMap<AccountDto, CustomerAccount>();

            CreateMap<SignUp, CustomerAccount>();

        }
    }
}

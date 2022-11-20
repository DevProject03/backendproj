using AutoMapper;
using BankingAPIs.ModelClass;
using BankingAPIs.DTOs;

namespace BankingAPIs.Helper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerAccount, AccountDTO >();

            CreateMap<AccountDTO, CustomerAccount>();

            CreateMap<SignUp, CustomerAccount>();

            //CreateMap<CustomerAccount, SignUp>();
        }
    }
}

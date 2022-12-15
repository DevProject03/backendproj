using BankingAPIs.DTOs;
using BankingAPIs.ModelClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAPIs.Test.Controller
{
    public class ControllerMockResponses
    {
        public static LoginDTO login ()
        {
            return new LoginDTO()
            {
                Email = "Aliix@gmail.com",
                Password = "string"
            };

        }
        public static AccountDto update()
        {
            return new AccountDto()
            {
                PhoneNumber = "08023415566",
                Email = "Aliix@gmail.com",
                Oldpassword = "string",
                Password = "string",
                ConfirmPassword = "string"


            };
        }

        public static SignUp Create() => new SignUp()
        {
            FirstName = "Toba",
            MiddleName = "Davis",
            LastName = "Lopez",
            DateOfBirth = DateTime.Now,
            PhoneNumber = "08022332167",
            Email = "Toba2@gmail.com",
            BVN = 54631282929,
            Password = "string",
            ConfirmPassword = "string",
            AccountTypes = "Savings",

        };
    }
}

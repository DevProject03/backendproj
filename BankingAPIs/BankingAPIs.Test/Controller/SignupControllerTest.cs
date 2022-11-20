using AutoMapper;
using BankingAPIs.Controllers;
using BankingAPIs.DATA;
using BankingAPIs.Interface;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAPIs.Test.Controller
{
    public class SignupControllerTest
    {
        private object _dbcontext;
        private object _mapper;
        private object _signup;

        public SignupControllerTest()
        {
            _dbcontext = A.Fake<DataBank>();
            _mapper = A.Fake<IMapper>();
            _signup = A.Fake<ISignUp>();
        }
        [Fact]
        public void SignUp_CreateUser_ReturnUser()
        {
            //Arrange
            //var controller = new SignUpController(dataBank, mapper, signUp);
            //Act
            //Assert
        }

    }
}

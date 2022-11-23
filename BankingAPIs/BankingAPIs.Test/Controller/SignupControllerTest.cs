using AutoMapper;
using BankingAPIs.Controllers;
using BankingAPIs.DATA;
using BankingAPIs.Interface;
using BankingAPIs.ModelClass;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAPIs.Test.Controller
{
    public class SignupControllerTest
    {
        private IMapper _mapper;
        private ISignUp _signup;

        public SignupControllerTest()
        {

            _mapper = A.Fake<IMapper>();
            _signup = A.Fake<ISignUp>();
        }
        [Fact]
        public void SignUp_CreateUser_ReturnUser()
        {
            //Arrange
            var signupacc = A.Fake<SignUp>();
            var acc = A.Fake<CustomerAccount>();

            A.CallTo(() => _mapper.Map<CustomerAccount>(signupacc));

            var controller = new SignUpController(_mapper, _signup);

            
            //Act

            var result = controller.CreateNewAccount(signupacc);
            //Assert

            Assert.NotNull(result);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

    }
}

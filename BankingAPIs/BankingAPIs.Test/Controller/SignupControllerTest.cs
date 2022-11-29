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
        private readonly IMapper _mapper;
        private readonly ISignUp _signup;

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

            A.CallTo(() => _signup.Create(signupacc, signupacc.Password,
                signupacc.ConfirmPassword)).Returns(new SignUp());
            
            var controller = new SignUpController( _signup);
           
            //Act

            var result = controller.CreateNewAccount(signupacc);

            //Assert

            Assert.NotNull(result);
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
            A.CallTo(() => _signup.Create(signupacc, signupacc.Password,
                signupacc.ConfirmPassword)).MustHaveHappened();
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }

    }
}

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
    public class CustomerControllerTest
    {
        //private DataBank _dbcontext;
        private IMapper _mapper;
        private ICustomerAccount _CustomerAccount;

        public CustomerControllerTest()
        {
            // _dbcontext = A.Fake<DataBank>();
            _mapper = A.Fake<IMapper>();
            _CustomerAccount = A.Fake<ICustomerAccount>();

        }
        [Fact]

        public void CustomerController_GetUser_ReturnUsers()
        {
            var User = A.Fake<ICollection<CustomerAccount>>().ToList();

            var Controller = new AccountController(_mapper, _CustomerAccount);

            var result = Controller.GetDetails();

            Assert.NotNull(result);
            result.Should().BeOfType(typeof(OkObjectResult));
            //result.Should().BeOfType(typeof(CustomerAccount));
            result.Should().NotBeNull();
            //result.Should().BeEquivalentTo(User); 

        }

        public void CustomerController_GetUserByAcc_ReturnUser()
        {
            var CustomerAccount = A.Fake<CustomerAccount>();

            string accnum = CustomerAccount.AccountGenerated;


            var Controller = new AccountController(_mapper, _CustomerAccount);

            var result = Controller.GetAccountByAccountNumber(accnum);

            result.Should().NotBeNull();
            result.Should().Be(CustomerAccount);
            //Assert.True()


        }
    }
}


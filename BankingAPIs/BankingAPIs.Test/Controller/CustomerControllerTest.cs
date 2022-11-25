using AutoMapper;
using BankingAPIs.Controllers;
using BankingAPIs.DATA;
using BankingAPIs.DTOs;
using BankingAPIs.Interface;
using BankingAPIs.ModelClass;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BankingAPIs.Test;


namespace BankingAPIs.Test.Controller
{
    public class CustomerControllerTest
    {
       
        private IMapper _mapper;
        private ICustomerAccount _CustomerAccount;
        private IList<CustomerAccount> _accRepo;
    
        public CustomerControllerTest()
        {
            
            _mapper = A.Fake<IMapper>();
            _CustomerAccount = A.Fake<ICustomerAccount>();
            _accRepo = A.CollectionOfFake<CustomerAccount>(9);
            
            //_services = new FakeRepo(mapper, _shoppingCart);

        }
        
        [Fact]

        public void CustomerController_GetUser_ReturnUsers()
        {
            var User = A.Fake<ICollection<CustomerAccount>>().ToList();

            var Controller = new AccountController(_CustomerAccount);

            var result = Controller.GetDetails() as OkObjectResult;


            
            Assert.NotNull(result);
            result.Should().BeOfType(typeof(OkObjectResult));
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
            //result.Should().BeOfType(typeof(CustomerAccount));
            result.Should().NotBeNull();
            //result.Should().BeEquivalentTo(User); 
            //result.StatusCode.Should().Be(200);

        }
        [Fact]
        public void CustomerController_GetUserByAcc_ReturnUser()
        {
            var CustomerAccount = A.Fake<CustomerAccount>();

            string accnum = CustomerAccount.AccountGenerated;


            var Controller = new AccountController(_CustomerAccount);

            var result = Controller.GetAccountByAccountNumber(accnum) as OkObjectResult;


            
            result.Should().NotBeNull();
            //result.Should().Be(CustomerAccount);
            Assert.IsType<OkObjectResult>(result);
            

            //Assert.True()


        }
        [Fact]
        public void CustomerController_GetUserBy_Search_ReturnUser()
        {
            var CustomerAccount = A.Fake<CustomerAccount>();

            //var SearchQuery = (CustomerAccount.Email);

            var User = A.Fake<ICollection<CustomerAccount>>().ToList();

            var SearchQuery = _accRepo.Where(a => a.Email.Contains(CustomerAccount.Email) 
            || a.AccountGenerated == CustomerAccount.AccountGenerated);

            var Controller = new AccountController( _CustomerAccount);

            //var result = Controller.Search();

        }

        [Fact]
        public void CustomerController_DeleteUserBy_Acc_ReturnNOContent()
        {
            var CustomerAccount = A.Fake<CustomerAccount>();
            string accnum = CustomerAccount.AccountGenerated;

            var Controller = new AccountController(_CustomerAccount);

            var result = Controller.DeleteCustomer(accnum);

            Assert.IsType<NoContentResult>(result);
            result.Should().NotBeNull();

        }

        [Fact]
        public void Remove_NotExisitinAcc_ReturnsNotFoundResponse()
        {
            // Arrange
          

            string acc = null;

            //var Controller = new AccountController(_CustomerAccount);


            // Act
            var Controller = new AccountController(_CustomerAccount);
            A.CallTo(() => _CustomerAccount.GetAccountByAccountNumber(acc)).Returns(null);
            A.CallTo(() => _CustomerAccount.DeleteCustomer(acc)).Equals(null);

           // var result = Controller.GetAccountByAccountNumber(acc) as NotFoundObjectResult;
           var result = Controller.DeleteCustomer(acc) as NotFoundObjectResult;
            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
            //result.Should().Be;
        }

        [Fact]
        public void CustomerController_updateUser_ReturnUser()
        {
            var CustomerAccount = A.Fake<CustomerAccount>();
            var CustomerDto = A.Fake<AccountDTO>();
            string accnum = CustomerAccount.AccountGenerated;

            var Controller = new AccountController(_CustomerAccount);

            var result = Controller.UpdateCustomer(CustomerDto, accnum);

            Assert.IsType<OkObjectResult>(result);
            result.Should().NotBeNull();

        }

        [Fact]
        public void CustomerController_Login_ReturnUser()
        {
            var CustomerAccount = A.Fake<CustomerAccount>();
            string email = CustomerAccount.Email;
            string pass = CustomerAccount.Password;

            var Controller = new AccountController(_CustomerAccount);

            var result = Controller.Login(email, pass) as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);


            result.Should().NotBeNull();

        }
        [Fact]
        public void CustomerController_WrongLoginDetails()
        {
            var CustomerAccount = A.Fake<CustomerAccount>();
            List<CustomerAccount> ShoppingCart = new List<CustomerAccount>()
            {
                new CustomerAccount() { FristName = "Lopez",
            LastName = "Sam",
            Email = "Samuel@gmail.com",
            Password = "Anu",
            PhoneNumber = "12344",
            AccountBalance = 0,
            AccountGenerated = "0291234567",
            //accountType = CustomerAccount.AccountType,
            DateCreated = DateTime.Now,
            DateOfBirth = DateTime.Now },

                new CustomerAccount() { FristName = "Lopez",
            LastName = "Sam",
            Email = "Samuel@gmail.com",
            Password = "Anu",
            PhoneNumber = "12344",
            AccountBalance = 0,
            AccountGenerated = "0291234567",
            //accountType = CustomerAccount.AccountType,
            DateCreated = DateTime.Now,
            DateOfBirth = DateTime.Now, },


                new CustomerAccount() { FristName = "Lopez",
            LastName = "Sam",
            Email = "Samuel@gmail.com",
            Password = "Anu",
            PhoneNumber = "12344",
            AccountBalance = 0,
            AccountGenerated = "0291234567",
            //accountType = CustomerAccount.AccountType,
            DateCreated = DateTime.Now,
            DateOfBirth = DateTime.Now, }
            };


            string email = ShoppingCart[1].Email;

            var user = ShoppingCart.Where(x => x.Email == email).FirstOrDefault();

            var pass = "aaa";

            //var Controller = new AccountController(ShoppingCart);

            //var result = Controller.Login(email, pass);

            Assert.IsType<NotFoundResult>(result);


            //result.Should().BeNull();

        }
       
    }
}


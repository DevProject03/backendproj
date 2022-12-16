using BankingAPIs.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankingAPIs.Test.Controller
{
    public class AccountControllerTest
    {

        [Fact]
        public async Task GetAccountById()
        {
            var factory = new WebApplicationFactory<AccountController>();

            var client = factory.CreateClient();

            HttpResponseMessage sutHttpResponse = await client.GetAsync($"/api/Account/getAccountById?Id=2");


            Assert.True(sutHttpResponse.IsSuccessStatusCode);
        }

        [Fact]

        public async Task Login()
        {
            var factory = new WebApplicationFactory<AccountController>();

            var client = factory.CreateClient();

            var parameters = ControllerMockResponses.login();

            HttpResponseMessage sutHttpResponse = await client.PostAsync($"/api/Account/Login",
                new StringContent(JsonConvert.SerializeObject(parameters), Encoding.Default, "application/json"));

            Assert.True(sutHttpResponse.IsSuccessStatusCode);

        }

        [Fact]
        public async Task GetAccountByName()
        {
            var factory = new WebApplicationFactory<AccountController>();

            var client = factory.CreateClient();

            HttpResponseMessage sutHttpResponse = await client.GetAsync($"/api/Account/getAccountByName?Name=Alex");

            Assert.True(sutHttpResponse.IsSuccessStatusCode);



        }

        [Fact]
        public async Task GetAccountByAccountNum()
        {
            var factory = new WebApplicationFactory<AccountController>();

            var client = factory.CreateClient();

            HttpResponseMessage sutHttpResponse = await client.GetAsync($"/api/Account/getAccountByAccountNumber?AccountNumber=0292610711");

            Assert.True(sutHttpResponse.IsSuccessStatusCode);

        }

        [Fact]
        public async Task GetAllAccount()
        {
            var factory = new WebApplicationFactory<AccountController>();

            var client = factory.CreateClient();

            HttpResponseMessage sutHttpResponse = await client.GetAsync($"/api/Account/getDetails");

            Assert.True(sutHttpResponse.IsSuccessStatusCode);

        }
        [Fact]
        public async Task SearchAccount()
        {
            var factory = new WebApplicationFactory<AccountController>();

            var client = factory.CreateClient();

            HttpResponseMessage sutHttpResponse = await client.GetAsync($"/api/Account/Search?SearchQuery=0297999069");

            Assert.True(sutHttpResponse.IsSuccessStatusCode);

        }

       /* [Fact]
        public async Task DeleteAccount()
        {
            var factory = new WebApplicationFactory<AccountController>();

            var client = factory.CreateClient();

            HttpResponseMessage sutHttpResponse = await client.DeleteAsync($"/api/Account/DeleteCustomer?AccountNumber=0297999069");

            Assert.True(sutHttpResponse.IsSuccessStatusCode);

        }*/

        [Fact]
        public async Task Update()
        {
            var factory = new WebApplicationFactory<AccountController>();

            var client = factory.CreateClient();

            var parameters = ControllerMockResponses.update();

            HttpResponseMessage sutHttpResponse = await client.PutAsync($"/api/Account/UpdateCustomer?AccountNumber=0295492415",
                new StringContent(JsonConvert.SerializeObject(parameters), Encoding.Default, "application/json"));

            Assert.True(sutHttpResponse.IsSuccessStatusCode);

        }



    }
 
}

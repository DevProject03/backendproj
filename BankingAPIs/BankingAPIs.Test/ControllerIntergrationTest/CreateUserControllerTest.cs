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
    public class CreateUserControllerTest
    {
        [Fact]

        public async Task Signup()
        {
            var factory = new WebApplicationFactory<SignUpController>();

            var client = factory.CreateClient();

            var parameters = ControllerMockResponses.Create();

            HttpResponseMessage sutHttpResponse = await client.PostAsync($"/api/SignUp/CreateNewAccount",
                new StringContent(JsonConvert.SerializeObject(parameters), Encoding.Default, "application/json"));

            Assert.True(sutHttpResponse.IsSuccessStatusCode);

        }
    }
}

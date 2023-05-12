using ArenaGestor.APIContracts.Security;
using ArenaGestor.APIContracts.Snacks;
using ArenaGestor.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace SFArenaGestor.Steps
{
    [Scope(Feature ="DeleteSnack")]
    [Binding]
    class DeleteSnackStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly Snack _snack = new Snack();
        private readonly User _adminUser = new User()
        {
            Email = "super@example.com",
            Password = "super"
        };
        private readonly User _nonAdminUser = new User()
        {
            Email = "espectador@example.com",
            Password = "test"
        };
        private string _token = "";
        private int _id;


        public DeleteSnackStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("a signed in admin user")]
        public async Task GivenASignedInAdminUser()
        {
            string requestBody = JsonConvert.SerializeObject(new { Email = _adminUser.Email, Password = _adminUser.Password });
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:44372/Security/login")
            {
                Content = new StringContent(requestBody)
                {
                    Headers =
                        {
                          ContentType = new MediaTypeHeaderValue("application/json")
                        }
                }
            };
            var client = new HttpClient();
            var response = await client.SendAsync(request).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();
            var resultParse = JsonConvert.DeserializeObject<SecurityTokenResponseDto>(result);
            _token = resultParse.Token;

        }

        [Given("a signed in non admin user")]
        public async Task GivenASignedInNonAdminUser()
        {
            string requestBody = JsonConvert.SerializeObject(new { Email = _nonAdminUser.Email, Password = _nonAdminUser.Password });
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:44372/Security/login")
            {
                Content = new StringContent(requestBody)
                {
                    Headers =
                        {
                          ContentType = new MediaTypeHeaderValue("application/json")
                        }
                }
            };
            var client = new HttpClient();
            var response = await client.SendAsync(request).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();
            var resultParse = JsonConvert.DeserializeObject<SecurityTokenResponseDto>(result);
            _token = resultParse.Token;

        }

        [Given(@"the user added a snack with name ""(.*)"", description ""(.*)"" and value ""(.*)""")]
        public async Task GivenTheUserAddedASnack(string name, string description, float price)
        {
            string requestBody = JsonConvert.SerializeObject(new { Name = name, Description = description, Price = price });
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:44372/Snacks")
            {
                Content = new StringContent(requestBody)
                {
                    Headers =
                        {
                          ContentType = new MediaTypeHeaderValue("application/json"),

                        }
                }
            };
            request.Headers.Add("token", _token);
            var client = new HttpClient();
            var response = await client.SendAsync(request).ConfigureAwait(false);
            try
            {
                var result = await response.Content.ReadAsStringAsync();
                var resultParse = JsonConvert.DeserializeObject<SnackResultDto>(result);
                _id = resultParse.SnackId;
            }
            catch (Exception) { }
        }

        [When("the user deletes the snack")]
        public async Task WhenTheUserDeletesTheSnack()
        {
            string requestBody = JsonConvert.SerializeObject(new { Name = _snack.Name, Description = _snack.Description, Price = _snack.Price });
            var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:44372/Snacks/{_id}")
            {
                Content = new StringContent(requestBody)
                {
                    Headers =
                        {
                          ContentType = new MediaTypeHeaderValue("application/json"),

                        }
                }
            };
            request.Headers.Add("token", _token);
            var client = new HttpClient();
            var response = await client.SendAsync(request).ConfigureAwait(false);
            _scenarioContext.Set(response.StatusCode, "ResponseStatusCode");
        }

        [When("the user deletes a snack with an invalid id")]
        public async Task WhenTheUserDeletesASnackWithAnInvalidId()
        {
            string requestBody = JsonConvert.SerializeObject(new { Name = _snack.Name, Description = _snack.Description, Price = _snack.Price });
            var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:44372/Snacks/-1")
            {
                Content = new StringContent(requestBody)
                {
                    Headers =
                        {
                          ContentType = new MediaTypeHeaderValue("application/json"),

                        }
                }
            };
            request.Headers.Add("token", _token);
            var client = new HttpClient();
            var response = await client.SendAsync(request).ConfigureAwait(false);
            _scenarioContext.Set(response.StatusCode, "ResponseStatusCode");
        }

        [Then(@"the message code should be ""(.*)""")]
        public void ThenTheMessageCodeShouldBe(int code)
        {
            Assert.Equal(code, (int)_scenarioContext.Get<HttpStatusCode>("ResponseStatusCode"));
        }
    }
}

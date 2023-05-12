using ArenaGestor.Domain;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using TechTalk.SpecFlow;
using ArenaGestor.APIContracts.Security;
using Xunit;
using System.Threading.Tasks;
using ArenaGestor.APIContracts.Snacks;

namespace SFArenaGestor.Steps
{
    [Scope(Feature = "AddSnack")]
    [Binding]
    public class AddSnackStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly Snack _snack = new Snack();
        private readonly User _nonAdminUser = new User()
        {
            Email = "espectador@example.com",
            Password = "test"
        };
        private readonly User _adminUser = new User()
        {
            Email = "super@example.com",
            Password = "super"
        };
        private string _token = "";
        private int _deleteAfterAddStep;

        public AddSnackStepDefinitions(ScenarioContext scenarioContext)
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

        [Given(@"the user entered the snack name ""(.*)""")]
        public void GivenTheSnackName(string name)
        {
            _snack.Name = name;
        }

        [Given(@"the user entered the snack description ""(.*)""")]
        public void GivenTheSnackDescription(string description)
        {
            _snack.Description = description;
        }

        [Given(@"the user entered the snack price ""(.*)""")]
        public void GivenTheSnackPrice(string price)
        {
            _snack.Price = float.Parse(price);
        }

        [When("the user adds the snack")]
        public async Task WhenIClickTheAddButton()
        {
            string requestBody = JsonConvert.SerializeObject(new { Name = _snack.Name, Description = _snack.Description, Price = _snack.Price });
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
                _deleteAfterAddStep = resultParse.SnackId;
            }
            catch (Exception) { }
            _scenarioContext.Set(response.StatusCode, "ResponseStatusCode");
        }

        [Then(@"the message code should be ""(.*)""")]
        public void ThenTheResultShouldBe(int code)
        {
            Assert.Equal(code, (int)_scenarioContext.Get<HttpStatusCode>("ResponseStatusCode"));
        }

        [AfterScenario("Add snack")]
        public async Task AfterTheUserAddsASnack()
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:44372/Snacks/{_deleteAfterAddStep}");
            request.Headers.Add("token", _token);

            var client = new HttpClient();
            var response = await client.SendAsync(request).ConfigureAwait(false);
        }
    }
}

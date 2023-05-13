using ArenaGestor.APIContracts.Concert;
using ArenaGestor.APIContracts.Security;
using ArenaGestor.APIContracts.Snacks;
using ArenaGestor.APIContracts.Ticket;
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
    [Scope(Feature = "BuySnack")]
    [Binding]
    public class BuySnackStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private TicketBuySnackDto _snack = new TicketBuySnackDto() { Name = "Null Snack" };
        private readonly User _spectatorUser = new User()
        {
            Email = "espectador@example.com",
            Password = "test"
        };
        private readonly User _adminSpectatorUser = new User()
        {
            Email = "administrador@example.com",
            Password = "test"
        };
        private readonly User _nonSpectatorUser = new User()
        {
            Email = "vendedor@example.com",
            Password = "test"
        };
        private string _token = "";
        private int _concertId;


        public BuySnackStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"a signed in spectator user")]
        public async Task GivenASignedInSpectatorUser()
        {
            string requestBody = JsonConvert.SerializeObject(new { Email = _spectatorUser.Email, Password = _spectatorUser.Password });
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

        [Given(@"a concert with available tickets")]
        public async Task GivenAConcertWithAvailableTickets()
        {
            string requestBody = JsonConvert.SerializeObject(new { Email = _adminSpectatorUser.Email, Password = _adminSpectatorUser.Password });
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

            Console.WriteLine("");
            ConcertInsertLocationDto location = new ConcertInsertLocationDto()
            {
                Place = "TestPlace",
                CountryId = 1,
                Street = "TestStreet",
                Number = 1
            };

            ConcertInsertProtagonistDto protagonist = new ConcertInsertProtagonistDto()
            {
                MusicalProtagonistId = 16
            };

            List<ConcertInsertProtagonistDto> protagonistList = new List<ConcertInsertProtagonistDto>() { protagonist };
            
            Random random = new Random();
            int randomNumber = random.Next(1, 99999);

            ConcertInsertConcertDto concert = new ConcertInsertConcertDto()
            {
                TourName = "TestTour",
                Date = DateTime.Now.AddDays(randomNumber),
                TicketCount = 20,
                Price = 10,
                Protagonists = protagonistList,
                Location = location
            };

            string requestBody2 = JsonConvert.SerializeObject(concert);
            var request2 = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:44372/Concerts")
            {
                Content = new StringContent(requestBody2)
                {
                    Headers =
                        {
                          ContentType = new MediaTypeHeaderValue("application/json")
                        }
                }
            };
            request2.Headers.Add("token", _token);
            var client2 = new HttpClient();
            var response2 = await client2.SendAsync(request2).ConfigureAwait(false);
            try
            {
                var result2 = await response2.Content.ReadAsStringAsync();
                var resultParse2 = JsonConvert.DeserializeObject<ConcertResultConcertDto>(result2);
                _concertId = resultParse2.ConcertId;
            }
            catch (Exception e
            ) {
                Console.WriteLine(e.ToString());
            }
        }

        [Given(@"a signed in non spectator user")]
        public async Task GivenASignedInNonSpectatorUser()
        {
            string requestBody = JsonConvert.SerializeObject(new { Email = _nonSpectatorUser.Email, Password = _nonSpectatorUser.Password });
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

        [Given(@"the user selected a snack to purchase with name ""(.*)"", description ""(.*)"", price ""(.*)"" and amount ""(.*)""")]
        public void TheUserSelectedASnack(string name, string description, int price, int amount)
        {
            _snack = new TicketBuySnackDto()
            {
                Name = name,
                Description = description,
                Price = price,
                Amount = amount
            };
        }

        [When("the user confirms the purchase")]
        public async Task WhenTheUserConfirmsThePurchase()
        {
            List<TicketBuySnackDto> list = new List<TicketBuySnackDto>();
            if(!_snack.Name.Equals("Null Snack"))
            {
                list.Add(_snack);
            }
            TicketBuyTicketDto ticket = new TicketBuyTicketDto()
            {
                ConcertId = _concertId,
                Snacks = list,
                Amount = 1
            };

            string requestBody = JsonConvert.SerializeObject(ticket);
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:44372/Tickets/Shopping")
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

        [AfterScenario("Buy a ticket with snacks", "Buy a ticket with an invalid user", "Buy a ticket with no snacks")]
        public async Task Cleanup()
        {
            string requestBody = JsonConvert.SerializeObject(new { Email = _adminSpectatorUser.Email, Password = _adminSpectatorUser.Password });
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

            var deleteRequest = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:44372/Concerts/{_concertId}");
            deleteRequest.Headers.Add("token", _token);
            var anotherClient = new HttpClient();
            var finalResponse = await anotherClient.SendAsync(deleteRequest).ConfigureAwait(false);

            _snack = new TicketBuySnackDto() { Name = "Null Snack" };
            _concertId = -1;
        }
    }
}

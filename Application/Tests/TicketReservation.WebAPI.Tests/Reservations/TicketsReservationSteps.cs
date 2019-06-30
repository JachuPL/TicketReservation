using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TicketReservation.Application.Account.Models;
using TicketReservation.Application.Cinemas.Models;
using TicketReservation.Application.Common.Database;
using TicketReservation.Application.Common.Mail;
using TicketReservation.Application.Movies.Models;
using TicketReservation.Application.Reservations.Models;
using TicketReservation.Application.Reservations.Requests;
using TicketReservation.Application.Shows.Requests;
using TicketReservation.Domain.Reservations;
using TicketReservation.WebAPI.Tests.Common;

namespace TicketReservation.WebAPI.Tests.Reservations
{
    [Binding]
    public class TicketsReservationSteps : AbstractIntegrationTestSession
    {
        private Guid _createdCinemaId;
        private Guid _createdMovieId;
        private Guid _createdShowId, _selectedShowId;
        private List<Place> _selectedPlaces = new List<Place>();
        private ReservationOffer _generatedOffer;
        private HttpStatusCode _reservationStatusCode;
        private ISendEmails _emailSender;

        public TicketsReservationSteps() : base()
        {
            var jwt = Task.Run(GetJwt).Result;
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, jwt);
        }

        private async Task<string> GetJwt()
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                Login = "user",
                Password = "user12345"
            };
            HttpResponseMessage response = await Client.PostAsJsonAsync("/api/login/", loginRequest);
            string responseContent = await response.Content.ReadAsStringAsync();
            JwtDto jwt = JsonConvert.DeserializeObject<JwtDto>(responseContent);
            return jwt.Token;
        }

        protected override void ServicesConfiguration(IServiceCollection services)
        {
            services.AddDbContext<TicketReservationContext>();
            services.AddEntityFrameworkInMemoryDatabase();
            services.AddAutoMapper(typeof(Startup).Assembly, typeof(TicketReservationContext).Assembly);
            _emailSender = A.Fake<ISendEmails>();
            services.AddSingleton(_emailSender);
        }

        [Given(@"now is ""(.*)""")]
        public void GivenNowIs(string datetime)
        {
        }

        [Given(@"cinema ""(.*)"" in ""(.*)"" is defined")]
        public async Task GivenCinemaInIsDefined(string cinema, string city)
        {
            CreateCinemaRequest request = new CreateCinemaRequest()
            {
                Name = cinema,
                City = city
            };
            HttpResponseMessage response = await Client.PostAsJsonAsync("/api/cinemas/", request);
            _createdCinemaId = GetGuidFromLocationHeader(response);
        }

        private static Guid GetGuidFromLocationHeader(HttpResponseMessage response)
        {
            string[] uriSegments = response.Headers.Location.Segments;
            return Guid.Parse(uriSegments[uriSegments.Length - 1]);
        }

        [Given(@"movie ""(.*)"" is defined")]
        public async Task GivenMovieIsDefined(string movie)
        {
            CreateMovieRequest request = new CreateMovieRequest()
            {
                Title = movie
            };
            HttpResponseMessage response = await Client.PostAsJsonAsync("/api/movies/", request);
            _createdMovieId = GetGuidFromLocationHeader(response);
        }

        [Given(@"show ""(.*)"" is played in cinema ""(.*)"" in ""(.*)"" on ""(.*)"" with ticket price of (.*) PLN")]
        public async Task GivenShowIsPlayedInCinemaInOnWithTicketPriceOfPLN(string movie, string cinema, string city, string datetime, int price)
        {
            CreateShowRequest request = new CreateShowRequest()
            {
                MovieId = _createdMovieId,
                Date = DateTime.Now.AddMinutes(60),
                PriceList = new List<TicketPrice>
                {
                    new TicketPrice
                    {
                        Kind =  Ticket.Normal,
                        Price = price
                    }
                }
            };
            HttpResponseMessage response = await Client.PostAsJsonAsync($"/api/cinemas/{_createdCinemaId}/shows", request);
            _createdShowId = GetGuidFromLocationHeader(response);
        }

        [Given(@"seat (.*) in row (.*) is reserved for ""(.*)"" in cinema ""(.*)"" in ""(.*)"" on ""(.*)""")]
        public async Task GivenSeatInRowIsReservedForInCinemaInOn(int seat, int row, string movie, string cinema, string city, string datetime)
        {
            var request = new ReservationOffer()
            {
                Price = 25,
                OfferRequest = new ReservationOfferRequest
                {
                    Places = new List<Place>
                    {
                        new Place
                        {
                            Ticket = Ticket.Normal,
                            Seat = seat,
                            Row = row
                        }
                    },
                    ShowId = _selectedShowId
                }
            };
            HttpResponseMessage response = await Client.PostAsJsonAsync("/api/reservations/", request);
        }

        [When(@"I select cinema ""(.*)"" in ""(.*)""")]
        public void WhenISelectCinemaIn(string cinema, string city)
        {
            // NOTE: for this purpose assume that cinema name is unique and we have 1 cinema available
        }

        [When(@"I select movie ""(.*)""")]
        public void WhenISelectMovie(string movie)
        {
            // NOTE: for this purpose assume that movie name is unique and we have 1 movie available
        }

        [When(@"I select show at ""(.*)""")]
        public void WhenISelectShowAt(string datetime)
        {
            // NOTE: for this purpose assume that show is defined as above
            _selectedShowId = _createdShowId;
        }

        [When(@"I select (.*) ticket")]
        public void WhenISelectTicket(int amount)
        {
        }

        [When(@"I select seat (.*) in row (.*)")]
        public void WhenISelectSeatInRow(int seat, int row)
        {
            // NOTE: For sake of simplicity we assume that a request was made previously to /shows/{_selectedShowId}/availableseats and this seat is available.
            // Otherwise, the flow would not match other scenarios
            _selectedPlaces.Add(new Place
            {
                Ticket = Ticket.Normal,
                Row = row,
                Seat = seat
            });
        }

        [When(@"I make a reservation")]
        public async Task WhenIMakeAReservation()
        {
            ReservationOffer reservationOffer = _generatedOffer;
            HttpResponseMessage response = await Client.PostAsJsonAsync("/api/reservations/", reservationOffer);
            string responseContent = await response.Content.ReadAsStringAsync();
            _reservationStatusCode = response.StatusCode;
        }

        [When(@"I select (.*) tickets")]
        public void WhenISelectTickets(int amount)
        {
        }

        [Then(@"the cost of reservation is (.*) PLN")]
        public async Task ThenTheCostOfReservationIsPLN(decimal price)
        {
            ReservationOfferRequest request = new ReservationOfferRequest
            {
                ShowId = _selectedShowId,
                Places = _selectedPlaces
            };
            var query = $"/api/reservations/offer?Showid={_selectedShowId}";
            for (int i = 0; i < _selectedPlaces.Count; i++)
            {
                query += $"&Places[{i}].Ticket={_selectedPlaces[i].Ticket}";
                query += $"&Places[{i}].Row={_selectedPlaces[i].Row}";
                query += $"&Places[{i}].Seat={_selectedPlaces[i].Seat}";
            }

            HttpResponseMessage response = await Client.GetAsync(query);
            string responseContent = await response.Content.ReadAsStringAsync();
            _generatedOffer = JsonConvert.DeserializeObject<ReservationOffer>(responseContent);
            _generatedOffer.OfferRequest.Should().BeEquivalentTo(request);
            _generatedOffer.Price.Should().Be(price);
        }

        [Then(@"the selected seats are reserved for me")]
        public void ThenTheSelectedSeatsAreReservedForMe()
        {
            _reservationStatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Then(@"I get an email with reservation confirmation")]
        public void ThenIGetAnEmailWithReservationConfirmation()
        {
            A.CallTo(() => _emailSender.Send(A<Email>.Ignored)).MustHaveHappened();
        }

        [Then(@"I see that seat (.*) in row (.*) is already reserved")]
        public async Task ThenISeeThatSeatInRowIsAlreadyReserved(int seat, int row)
        {
            HttpResponseMessage response = await Client.GetAsync($"/api/shows/{_selectedShowId}/availableseats");
            List<Place> availablePlaces = JsonConvert.DeserializeObject<List<Place>>(await response.Content.ReadAsStringAsync());
            availablePlaces.Should().NotContain(x => x.Seat == seat && x.Row == row);
        }
    }
}
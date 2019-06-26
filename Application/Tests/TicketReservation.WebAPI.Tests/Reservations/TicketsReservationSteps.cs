using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TicketReservation.Application.Common.Database;
using TicketReservation.WebAPI.Cinemas.Requests;
using TicketReservation.WebAPI.Movies.Requests;
using TicketReservation.WebAPI.Shows.Requests;
using TicketReservation.WebAPI.Tests.Common;

namespace TicketReservation.WebAPI.Tests.Reservations
{
    [Binding]
    public class TicketsReservationSteps : AbstractIntegrationTestSession
    {
        private DateTime _now;
        private Guid _cinemaId;
        private Guid _movieId;
        private Guid _showId;

        protected override void ServicesConfiguration(IServiceCollection services)
        {
            services.AddDbContext<TicketReservationContext>();
            services.AddEntityFrameworkInMemoryDatabase();
            services.AddAutoMapper(typeof(Startup).Assembly, typeof(TicketReservationContext).Assembly);
        }

        [Given(@"now is ""(.*)""")]
        public void GivenNowIs(string datetime)
        {
            _now = DateTime.ParseExact(datetime, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
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
            string content = await response.Content.ReadAsStringAsync();
            _cinemaId = Guid.Parse(content.Replace("\"", string.Empty));
        }

        [Given(@"movie ""(.*)"" is defined")]
        public async Task GivenMovieIsDefined(string movie)
        {
            CreateMovieRequest request = new CreateMovieRequest()
            {
                Title = "Smoleńsk"
            };
            HttpResponseMessage response = await Client.PostAsJsonAsync("/api/movies/", request);
            string content = await response.Content.ReadAsStringAsync();
            _movieId = Guid.Parse(content.Replace("\"", string.Empty));
        }

        [Given(@"show ""(.*)"" is played in cinema ""(.*)"" in ""(.*)"" on ""(.*)"" with ticket price of (.*) PLN")]
        public async Task GivenShowIsPlayedInCinemaInOnWithTicketPriceOfPLN(string movie, string cinema, string city, string datetime, int price)
        {
            DateTime date = DateTime.ParseExact(datetime, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            CreateShowRequest request = new CreateShowRequest()
            {
                MovieId = _movieId,
                CinemaId = _cinemaId,
                Date = date,
                PriceList = new List<TicketPrice>
                {
                    new TicketPrice
                    {
                        Kind =  TicketKind.Normal,
                        Price = price
                    }
                }
            };
            HttpResponseMessage response = await Client.PostAsJsonAsync("/api/shows/", request);
            string content = await response.Content.ReadAsStringAsync();
            _showId = Guid.Parse(content.Replace("\"", string.Empty));
        }

        [Given(@"seat (.*) in row (.*) is reserved for ""(.*)"" in cinema ""(.*)"" in ""(.*)"" on ""(.*)""")]
        public void GivenSeatInRowIsReservedForInCinemaInOn(int seat, int row, string movie, string cinema, string city, string datetime)
        {
            // TODO: POST /reservations/
            ScenarioContext.Current.Pending();
        }

        [When(@"I select cinema ""(.*)"" in ""(.*)""")]
        public void WhenISelectCinemaIn(string cinema, string city)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select movie ""(.*)""")]
        public void WhenISelectMovie(string movie)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select show at ""(.*)""")]
        public void WhenISelectShowAt(string datetime)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select (.*) ticket")]
        public void WhenISelectTicket(int amount)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select seat (.*) in row (.*)")]
        public void WhenISelectSeatInRow(int seat, int row)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I make a reservation")]
        public void WhenIMakeAReservation()
        {
            // TODO: POST /reservations/
            ScenarioContext.Current.Pending();
        }

        [When(@"I select (.*) tickets")]
        public void WhenISelectTickets(int amount)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the cost of reservation is (.*) PLN")]
        public void ThenTheCostOfReservationIsPLN(int price)
        {
            // TODO: assert returned price
            ScenarioContext.Current.Pending();
        }

        [Then(@"the selected seats are reserved for me")]
        public void ThenTheSelectedSeatsAreReservedForMe()
        {
            // TODO: GET /show/x/seats
            ScenarioContext.Current.Pending();
        }

        [Then(@"I get an email with reservation confirmation")]
        public void ThenIGetAnEmailWithReservationConfirmation()
        {
            // TODO: mock mail sender
            ScenarioContext.Current.Pending();
        }

        [Then(@"I see that seat (.*) in row (.*) is already reserved")]
        public void ThenISeeThatSeatInRowIsAlreadyReserved(int seat, int row)
        {
            // TODO: GET /show/x/seats
            ScenarioContext.Current.Pending();
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using TechTalk.SpecFlow;
using TicketReservation.WebAPI.Tests.Common;

namespace TicketReservation.WebAPI.Tests.Reservations
{
    [Binding]
    public class TicketsReservationSteps : AbstractIntegrationTestSession
    {
        private DateTime _now;

        protected override void ServicesConfiguration(IServiceCollection services)
        {
        }

        [Given(@"now is ""(.*)""")]
        public void GivenNowIs(string datetime)
        {
            _now = DateTime.ParseExact("yyyy-MM-dd HH:mm", datetime, CultureInfo.InvariantCulture);
        }

        [Given(@"cinema ""(.*)"" in ""(.*)"" is defined")]
        public void GivenCinemaInIsDefined(string cinema, string city)
        {
            // TODO: POST /cinemas/
            //{
            //  "Name": {cinema},
            //  "City": {city}
            //}
            ScenarioContext.Current.Pending();
        }

        [Given(@"movie ""(.*)"" is defined")]
        public void GivenMovieIsDefined(string movie)
        {
            // TODO: POST /movies/
            ScenarioContext.Current.Pending();
        }

        [Given(@"show ""(.*)"" is played in cinema ""(.*)"" in ""(.*)"" on ""(.*)"" with ticket price of (.*) PLN")]
        public void GivenShowIsPlayedInCinemaInOnWithTicketPriceOfPLN(string movie, string cinema, string city, string datetime, int price)
        {
            // TODO: POST /shows/
            ScenarioContext.Current.Pending();
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
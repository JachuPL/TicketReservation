using System;
using TechTalk.SpecFlow;

namespace TicketReservation.Domain.Tests
{
    [Binding]
    public class TicketsReservationSteps
    {
        [Given(@"now is ""(.*)""")]
        public void GivenNowIs(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"cinema ""(.*)"" in ""(.*)"" is defined")]
        public void GivenCinemaInIsDefined(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"movie ""(.*)"" is defined")]
        public void GivenMovieIsDefined(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"show ""(.*)"" is played in cinema ""(.*)"" in ""(.*)"" on ""(.*)""")]
        public void GivenShowIsPlayedInCinemaInOn(string p0, string p1, string p2, string p3)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the ticket cost is (.*) PLN")]
        public void GivenTheTicketCostIsPLN(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"seat (.*) in row (.*) is reserved for ""(.*)"" in cinema ""(.*)"" in ""(.*)"" on ""(.*)""")]
        public void GivenSeatInRowIsReservedForInCinemaInOn(int p0, int p1, string p2, string p3, string p4, string p5)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I select cinema ""(.*)"" in ""(.*)""")]
        public void WhenISelectCinemaIn(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I select movie ""(.*)""")]
        public void WhenISelectMovie(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I select show at ""(.*)""")]
        public void WhenISelectShowAt(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I select (.*) ticket")]
        public void WhenISelectTicket(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I select seat (.*) in row (.*)")]
        public void WhenISelectSeatInRow(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I make a reservation")]
        public void WhenIMakeAReservation()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I select (.*) tickets")]
        public void WhenISelectTickets(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the cost of reservation is (.*) PLN")]
        public void ThenTheCostOfReservationIsPLN(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the selected seats are reserved for me")]
        public void ThenTheSelectedSeatsAreReservedForMe()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I get an email with reservation confirmation")]
        public void ThenIGetAnEmailWithReservationConfirmation()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I see that seat (.*) in row (.*) is already reserved")]
        public void ThenISeeThatSeatInRowIsAlreadyReserved(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
    }
}

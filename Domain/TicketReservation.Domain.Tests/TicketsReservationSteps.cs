using TechTalk.SpecFlow;

namespace TicketReservation.Domain.Tests
{
    [Binding]
    public class TicketsReservationSteps
    {
        [Given(@"now is ""(.*)""")]
        public void GivenNowIs(string datetime)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"cinema ""(.*)"" in ""(.*)"" is defined")]
        public void GivenCinemaInIsDefined(string cienameName, string city)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"movie ""(.*)"" is defined")]
        public void GivenMovieIsDefined(string movieName)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"show ""(.*)"" is played in cinema ""(.*)"" in ""(.*)"" on ""(.*)""")]
        public void GivenShowIsPlayedInCinemaInOn(string movieName, string cinemaName, string city, string date)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"the ticket cost is (.*) PLN")]
        public void GivenTheTicketCostIsPLN(int price)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"seat (.*) in row (.*) is reserved for ""(.*)"" in cinema ""(.*)"" in ""(.*)"" on ""(.*)""")]
        public void GivenSeatInRowIsReservedForInCinemaInOn(int seat, int row, string client, string cinema, string city, string date)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select cinema ""(.*)"" in ""(.*)""")]
        public void WhenISelectCinemaIn(string cinema, string city)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select movie ""(.*)""")]
        public void WhenISelectMovie(string movieName)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select show at ""(.*)""")]
        public void WhenISelectShowAt(string date)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select (.*) ticket")]
        public void WhenISelectTicket(int amount)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I select seat (.*) in row (.*)")]
        public void WhenISelectSeatInRow(int seat, int ron)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I make a reservation")]
        public void WhenIMakeAReservation()
        {
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
        public void ThenISeeThatSeatInRowIsAlreadyReserved(int seat, int row)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
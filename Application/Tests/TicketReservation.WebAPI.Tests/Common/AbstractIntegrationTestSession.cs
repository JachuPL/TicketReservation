using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace TicketReservation.WebAPI.Tests.Common
{
    public abstract class AbstractIntegrationTestSession
    {
        private WebApplicationFactory<Startup> ApplicationFactory { get; }
        protected HttpClient Client { get; }

        protected AbstractIntegrationTestSession()
        {
            ApplicationFactory = new WebApplicationFactory<Startup>().WithWebHostBuilder(CustomWebHostBuilder);
            Client = ApplicationFactory.CreateClient();
        }

        private void CustomWebHostBuilder(IWebHostBuilder builder)
        {
            builder.ConfigureServices(ServicesConfiguration);
        }

        protected abstract void ServicesConfiguration(IServiceCollection services);
    }
}
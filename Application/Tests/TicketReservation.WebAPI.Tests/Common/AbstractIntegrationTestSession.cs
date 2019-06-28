using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.TestHost;

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
            builder.ConfigureTestServices(ServicesConfiguration);
        }

        protected abstract void ServicesConfiguration(IServiceCollection services);
    }
}
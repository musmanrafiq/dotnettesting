using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp_MVC;
using Xunit;

namespace WebApp_MVC_IntegrationTests
{
    public class HomeTests : IClassFixture<TestFixture<Startup>>
    {
            private HttpClient Client;

            public HomeTests(TestFixture<Startup> fixture)
            {
                Client = fixture.Client;
            }

            [Fact]
            public async Task TestGetHomeIndexAsync()
            {
                // Arrange
                var request = "/";

                // Act
                var response = await Client.GetAsync(request);

                // Assert
                //response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                Assert.True(responseString.Length > 0);
            }

        [Fact]
        public async Task BasicEndPointTest()
        {
            // Arrange
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
            // Add TestServer
            webHost.UseTestServer();
                    webHost.UseStartup<WebApp_MVC.Startup>();
                });

            // Create and start up the host
            var host = await hostBuilder.StartAsync();

            // Create an HttpClient which is setup for the test host
            var client = host.GetTestClient();

            // Act
            var response = await client.GetAsync("/Home");

            // Assert
            var responseString = await response.Content.ReadAsStringAsync();

        }

    }
}

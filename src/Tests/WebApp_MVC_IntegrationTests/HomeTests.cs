using System.Net.Http;
using System.Threading.Tasks;
using WebApp_MVC;
using Xunit;

namespace WebApp_MVC_IntegrationTests
{
    public class HomeTests
    {
        public class WarehouseTests : IClassFixture<TestFixture<Startup>>
        {
            private HttpClient Client;

            public WarehouseTests(TestFixture<Startup> fixture)
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


        }
    }
}

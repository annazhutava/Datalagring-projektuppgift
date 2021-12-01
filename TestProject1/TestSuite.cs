using System.Linq;
using DataLayer.Backend;
using DataLayer.Data;
using Xunit;

namespace BackendTests
{
    public class TestSuite
    {
        [Fact]
        public void AdminBackendTest()
        {
            using var ctx = new TrackingDb();
            AdminBackend adminBackend = new AdminBackend();

            adminBackend.PrepDatabase();
            adminBackend.AddRestaurant("Hästen", "Dalarna", "Älvdalen", "0251-10010");

            var query = ctx
                .Restaurants
                .Where(r => r.Name == "Hästen");
            var newRestaurant = query.First();

            Assert.Equal("Hästen", newRestaurant.Name);

        }
    }
}
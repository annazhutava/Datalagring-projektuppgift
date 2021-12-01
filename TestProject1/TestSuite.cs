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
            adminBackend.AddRestaurant("H�sten", "Dalarna", "�lvdalen", "0251-10010");

            var query = ctx
                .Restaurants
                .Where(r => r.Name == "H�sten");
            var newRestaurant = query.First();

            Assert.Equal("H�sten", newRestaurant.Name);

        }
    }
}
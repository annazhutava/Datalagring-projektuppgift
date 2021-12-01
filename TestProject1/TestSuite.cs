using System.Linq;
using DataLayer.Backend;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BackendTests
{
    public class TestSuite
    {
        private RestaurantBackend _restaurantBackend;
        public TestSuite()
        {
            _restaurantBackend = new RestaurantBackend();

            var admin = new AdminBackend();
            admin.PrepDatabase();
        }

        [Fact]
        public void RestaurantBackendTest()
        {
            _restaurantBackend.AddLunchbox("Nachos", "69", "Veg", "O'Learys");

            using var ctx = new TrackingDb();

            var query = ctx.LunchBoxes
                .Where(l => l.Dish == "Nachos");

            var newLunhcbox = query.First();

            Assert.Equal("Nachos", newLunhcbox.Dish);
        }
        [Fact]
        public void UserBackendTest()
        {
            using var ctx = new TrackingDb();
            var userTools = new UserBackend();
            var adminTools = new AdminBackend();
            adminTools.PrepDatabase();

            var query = ctx
                .LunchBoxes
                .Where(l => l.Id == 2)
                .Include(l => l.Customer);

            var lunchbox = query.First();

            Assert.True(lunchbox.Customer == null);

            userTools.BuyLunchbox("pontusberg830@gmail.com", 2);
            using var ctx2 = new TrackingDb();
            query = ctx2
                .LunchBoxes
                .Where(l => l.Id == 2)
                .Include(l => l.Customer);
            lunchbox = query.First();

            Assert.Equal("pontusberg830@gmail.com", lunchbox.Customer.Email);

        }
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
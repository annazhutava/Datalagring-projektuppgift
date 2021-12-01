using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Backend;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BackendTests
{
    public class Tests
    {
        private RestaurantBackend _restaurantBackend;
        public Tests()
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
    }
}

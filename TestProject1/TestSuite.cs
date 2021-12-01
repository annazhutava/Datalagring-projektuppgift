using DataLayer.Backend;
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace BackendTests
{
    public class TestSuite
    {
        [Fact]
        public void UserBackEndTest()
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
    }
}
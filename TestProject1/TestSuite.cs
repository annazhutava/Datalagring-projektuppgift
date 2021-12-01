using System.Linq;
using DataLayer.Data;
using Xunit;

namespace BackendTests
{
    public class TestSuite
    {
        [Fact]
        public void AdminLoginTest()
        {
            using var ctx = new TrackingDb();
            var query = ctx
                .Admin
                .Where(a => a.UserName != null);
        }
    }
}
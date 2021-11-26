using Xunit;

namespace BackendTests
{
    public class TestSuite
    {
        public LoginTestSuite()
        {
            var database = new Database();
            database.
                ();
        }
        [Fact]
        public void Test1()
        {
            var login = new Login();
            Assert.True(login.Attempt("username", "Password"));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Data;

namespace DataLayer.TestSuite
{
    public class Tests
    {
        public void ResetDatabase() //<---resettar databasen inför varje test?
        {
            using var ctx = new TrackingDb();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            ctx.Seed();
        }
    }
}

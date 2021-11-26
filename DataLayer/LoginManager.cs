using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Backend;
using DataLayer.Data;
using DataLayer.Model;

namespace DataLayer
{
    public class LoginManager
    {
        public Admin TryLoginAdmin(string username, string password)
        {
            using var ctx = new TrackingDb();
            var query = ctx
                .Admin
                .Where(a => a.UserName == username);
            var admin = query.FirstOrDefault();
            bool adminExists = admin != null;
            if (adminExists)
            {
                bool passwordMatches = admin.Password == password;
                if (passwordMatches)
                {
                    return admin;
                }
            }

            return null;
        }
    }
}

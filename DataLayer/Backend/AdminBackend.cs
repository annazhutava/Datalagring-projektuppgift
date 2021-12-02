using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Data;
using DataLayer.Model;

namespace DataLayer.Backend
{
    public class AdminBackend
    {
        public void PrepDatabase()
        {
            using var ctx = new TrackingDb();
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            ctx.Seed();
        }

        public void ShowUsers()
        {
            using var ctx = new TrackingDb();
            var query = ctx
                .Customers;
            foreach (var customer in query)
            {
                string name = customer.Name;
                string email = customer.Email;
                string phone = customer.PhoneNumber;
                Console.Write($"{name}, {email}, {phone}\n");
            }
            Console.Write("\n");
        }
        
        public void AddRestaurant(string name, string city, string street, string phonenumber)
        {
            using var ctx = new TrackingDb();

            var newRestaurant = new Restaurant()
            {
                Name = name,
                City = city,
                Address = street,
                PhoneNumber = phonenumber
            };

            ctx.Add(newRestaurant);
            ctx.SaveChanges();
        }
        public void ShowRestaurants()
        {
            using var ctx = new TrackingDb();
            var query = ctx
                .Restaurants;
            foreach (var restaurant in query)
            {
                string name = restaurant.Name;
                string address = restaurant.Address;
                string phone = restaurant.PhoneNumber;
                string city = restaurant.City;
                Console.Write($"{name}, {city}, {address}, {phone}\n");
            }
        }
    }
    
}

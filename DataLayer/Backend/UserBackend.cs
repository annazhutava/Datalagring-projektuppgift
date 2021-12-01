using System;
using System.Linq;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Backend
{
    public class UserBackend
    {
        public void AvailableLunchboxes()
        {
            using var ctx = new TrackingDb();
            var query = ctx
                .LunchBoxes
                .Where(l => l.Customer == null)
                .OrderBy(l => l.Price)
                .Include(l => l.Restaurant);

            foreach (var lunchbox in query)
            {
                var name = lunchbox.Dish;
                var restaurant = lunchbox.Restaurant.Name;
                var price = lunchbox.Price;
                var id = lunchbox.Id;
                var type = lunchbox.FoodType;
                Console.WriteLine($"{id}: {name}({type}), {restaurant}, {price}");
            }
            Console.WriteLine("\n");
        }

        public void BuyLunchbox(string userEmail, int dish)
        {
            using var ctx = new TrackingDb();
            var query = ctx
                .Customers
                .Where(c => c.Email == userEmail);
            var customer = query.First();

            var query2 = ctx
                .LunchBoxes
                .Where(l => l.Id == dish);
            var lunchbox = query2.First();

            if (lunchbox.Customer == null)
            {
                lunchbox.Customer = customer;
            }
            
            ctx.SaveChanges();
        }
        public void AvailableLunchboxesType(string mattyp)
        {
            using var ctx = new TrackingDb();
            mattyp = mattyp.ToLower();
            if (mattyp == "kött")
            {
                var query = ctx
                    .LunchBoxes
                    .Where(l => l.Customer == null && l.FoodType == "Kött")
                    .OrderBy(l => l.Price)
                    .Include(l => l.Restaurant);
                foreach (var lunchbox in query)
                {
                    var name = lunchbox.Dish;
                    var restaurant = lunchbox.Restaurant.Name;
                    var price = lunchbox.Price;
                    var id = lunchbox.Id;
                    var type = lunchbox.FoodType;
                    Console.WriteLine($"{id}: {name}({type}), {restaurant}, {price}");
                }
                Console.WriteLine("\n");
            }
            if (mattyp == "fisk")
            {
                var query = ctx
                    .LunchBoxes
                    .Where(l => l.Customer == null && l.FoodType == "Fisk")
                    .OrderBy(l => l.Price)
                    .Include(l => l.Restaurant);
                foreach (var lunchbox in query)
                {
                    var name = lunchbox.Dish;
                    var restaurant = lunchbox.Restaurant.Name;
                    var price = lunchbox.Price;
                    var id = lunchbox.Id;
                    var type = lunchbox.FoodType;
                    Console.WriteLine($"{id}: {name}({type}), {restaurant}, {price}");
                }
                Console.WriteLine("\n");
            }
            if (mattyp == "veg")
            {
                var query = ctx
                    .LunchBoxes
                    .Where(l => l.Customer == null && l.FoodType == "Veg")
                    .OrderBy(l => l.Price)
                    .Include(l => l.Restaurant);
                foreach (var lunchbox in query)
                {
                    var name = lunchbox.Dish;
                    var restaurant = lunchbox.Restaurant.Name;
                    var price = lunchbox.Price;
                    var id = lunchbox.Id;
                    var type = lunchbox.FoodType;
                    Console.WriteLine($"{id}: {name}({type}), {restaurant}, {price}");
                }
                Console.WriteLine("\n");
            }
            else { return; }
        }
    }
}

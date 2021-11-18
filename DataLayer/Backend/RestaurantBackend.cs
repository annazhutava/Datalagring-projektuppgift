using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Backend
{
    public class RestaurantBackend
    {
        public void SoldLunchBoxes(string restaurantName)
        {
            using var ctx = new TrackingDb();
            var query = ctx
                .Restaurants
                .Where(r => r.Name == restaurantName);
            var restaurant = query.First();
            var rId = restaurant.Id;

            var query2 = ctx.LunchBoxes
                .Where(l => l.Restaurant.Id == rId)
                .Where(l => l.Customer != null);
            Console.WriteLine($"Sålda matlådor för {restaurantName}: \n");
            foreach (var lunchbox in query2)
            {
                var name = restaurant.Name;
                var food = lunchbox.Dish;
                var price = lunchbox.Price;
                Console.WriteLine($"{name}\n{food} {price}:-\n");
            }

        }

        public void AddLunchbox(string Dish, string Price, string Type, string restaurantName)
        {
            using var ctx = new TrackingDb();
            var query = ctx
                .Restaurants
                .Where(r => r.Name == restaurantName);
            var restaurant = query.First();


            var lunchbox = new LunchBox();
            {
                lunchbox.Dish = Dish;
                lunchbox.Price = Price;
                lunchbox.FoodType = Type;
                lunchbox.Restaurant = restaurant;
                lunchbox.Customer = null;
            }
            ctx.Add(lunchbox);
            ctx.SaveChanges();
        }
    }
}

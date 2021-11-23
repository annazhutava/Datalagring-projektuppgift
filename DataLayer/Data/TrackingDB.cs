using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DataLayer.Data
{
    public class TrackingDb : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LunchBox> LunchBoxes { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Admin> Admin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Customer>(c =>
            {
                c.HasIndex(c => c.Email)
                    .IsUnique();
                c.HasIndex(c => c.PhoneNumber);
                c.HasIndex(c => c.Name);
            });
            modelbuilder.Entity<Restaurant>(r =>
            {
                r.HasIndex(r => r.Name);
                r.HasIndex(r => r.PhoneNumber)
                    .IsUnique();
                r.HasIndex(r => r.City);
                r.HasIndex(r => r.Address);
            });
            modelbuilder.Entity<LunchBox>(l =>
            {
                l.HasIndex(l => l.Dish);
                l.HasIndex(l => l.FoodType);
                l.HasIndex(l => l.Price);
            });
            modelbuilder.Entity<Admin>(a =>
            {
                a.HasIndex(a => a.UserName)
                    .IsUnique();
                a.HasIndex(a => a.Password);
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=InlTvå");
        }

        public void Seed()
        {
            var customers = new Customer[]
            {
                new()
                {
                    Name = "Pontus Berg", Email = "pontusberg830@gmail.com", PhoneNumber = "0735332152"

                },
                new()
                {
                    Name = "Kwame Karikari", Email = "kwamekarikari22@gmail.com", PhoneNumber = "0703123782"
                },
                new()
                {
                    Name = "Per Karlsson", Email = "perkarlsson3@gmail.com", PhoneNumber = "0708258191"
                },
                new()
                {
                    Name = "Celso Borges", Email = "celsoborges@gmail.com", PhoneNumber = "0731258512"
                },
                new()
                {
                    Name = "Ivan Obolo", Email = "ivanobolo@gmail.com", PhoneNumber = "0712313451"
                }
            };
            Customers.AddRange(customers);

            var restaurants = new Restaurant[]
            {
                new()
                {
                    Name = "O'Learys", City = "Stockholm", Address = "Slöjdgatan 11", PhoneNumber = "020103181"
                },
                new()
                {
                    Name = "Lett", City = "Stockholm", Address = "Sveavägen 23", PhoneNumber = "0728587818"
                },
                new()
                {
                    Name = "Urban Deli", City = "Stockholm", Address = "Sveavägen 44", PhoneNumber = "0842550020"
                }
            };
            Restaurants.AddRange(restaurants);
            var lunchboxes = new LunchBox[]
            {
                new()
                {
                    Dish = "Fish n Chips'", Price = "70", FoodType = "Fish", Restaurant = restaurants[0], Customer = customers[0]
                },
                new()
                {
                    Dish = "Höstgryta", Price = "70", FoodType = "Meat", Restaurant = restaurants[0], Customer = null
                },
                new()
                {
                    Dish = "Oxbringa", Price = "70", FoodType = "Meat", Restaurant = restaurants[0], Customer = null
                },
                new ()
                {
                    Dish = "Rosastekt Biff", Price = "70", FoodType = "Meat", Restaurant = restaurants[0], Customer = null
                },
                new ()
                {
                    Dish = "Mexikansk Wrap", Price = "80", FoodType = "Meat", Restaurant = restaurants[1], Customer = null
                },
                new ()
                {
                    Dish = "Sötpotatissallad", Price = "77", FoodType = "Veg", Restaurant = restaurants[1], Customer = null
                },
                new()
                {
                    Dish = "Pulled vegme sallad", Price = "61", FoodType = "Veg", Restaurant = restaurants[1], Customer = null
                },
                new()
                {
                    Dish = "Kyckling Bowl", Price = "72", FoodType = "Meat", Restaurant = restaurants[1], Customer = null
                },
                new()
                {
                    Dish = "Teriyaki Lax", Price = "70", FoodType = "Fish", Restaurant = restaurants[2], Customer = null
                },
                new()
                {
                    Dish = "Räksallad", Price = "60", FoodType = "Fish", Restaurant = restaurants[2], Customer = null
                },
                new()
                {
                    Dish = "Veg Lasagne", Price = "69", FoodType = "Veg", Restaurant = restaurants[2], Customer = null
                },
                new ()
                {
                    Dish = "Kycklingsallad", Price = "58", FoodType = "Meat", Restaurant = restaurants[2], Customer = null
                }
            };
            LunchBoxes.AddRange(lunchboxes);

            var admins = new Admin[]
            {
                new() {UserName = "A", Password = "A"}
            };
            
            SaveChanges();
        }
    }
}

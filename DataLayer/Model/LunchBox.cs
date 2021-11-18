using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class LunchBox
    {
        [Key] public int Id { get; set; }
        public string Dish { get; set; }
        public string Price { get; set; }
        public string FoodType { get; set; }
        [ForeignKey("RestaurantId")] public Restaurant Restaurant { get; set; }
        [ForeignKey("CustomerId")] public Customer Customer { get; set; }
    }
}

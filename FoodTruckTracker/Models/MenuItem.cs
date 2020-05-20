using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruckTracker.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public double QuantityLeft { get; set; }

        [ForeignKey("FoodTruck")]
        public string FoodTruckId { get; set; }
        public FoodTruck FoodTruck { get; set; }
    }
}

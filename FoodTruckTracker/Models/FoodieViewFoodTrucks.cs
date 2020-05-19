using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruckTracker.Models
{
    public class FoodieViewFoodTrucks
    {
        public Foodie Foodie { get; set; }
        public List<FoodTruck> FoodTrucks { get; set; }
    }
}

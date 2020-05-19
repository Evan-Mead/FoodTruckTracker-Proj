using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruckTracker.Models
{
    public class FoodTruckProfile
    {
        public FoodTruck FoodTruck { get; set; }
        public string TruckStory { get; set; }
        public string TruckCrew { get; set; }
        public string CuisineType { get; set; }
    }
}

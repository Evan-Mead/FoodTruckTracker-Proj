using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruckTracker.Models
{
    public class FoodTruck
    {
        [Key]
        public int FoodTruckId { get; set; }
        public string FoodTruckName { get; set; }
        public double ProfileViews { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CuisineType { get; set; }
        public string TruckHistory { get; set; }
        public string TruckCrew { get; set; }
        public List<Review> Reviews { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}

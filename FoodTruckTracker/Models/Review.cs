using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruckTracker.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        [ForeignKey("FoodTruck")]
        public string FoodTruckId { get; set; }
        public FoodTruck FoodTruck { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}

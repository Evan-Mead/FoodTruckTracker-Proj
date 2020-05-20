using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodTruckTracker.Models
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }
        public string Data { get; set; }

        [ForeignKey("FoodTruck")]
        public string FoodTruckId { get; set; }
        public FoodTruck FoodTruck { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assignment7.Queue
{
    public class RestaurantOpt
    {
        [RegularExpression("add|update|delete", ErrorMessage = "the command must be either add/update/delete ")]
        public string command { get; set; }
        [Required]
        public Restaurant restaurant { get; set; } 
    }
}

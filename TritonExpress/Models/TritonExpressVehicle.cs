using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TritonExpress.Models
{
    public class TritonExpressVehicle
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Branch")]
        public string branch { get; set; }
        [Display(Name = "Vehicle Year")]
        public int vehicleyear { get; set; }
        [Display(Name = "Vehicle Make")]
        public string vehiclemake { get; set; }
        [Display(Name = "Vehicle Model")]
        public string vehiclemodel { get; set; }
        [Required]
        [Display(Name = "Vehicle Registration")]
        public string vehiclereg { get; set; }
        [Display(Name = "WayBill")]
        public int wayBillID { get; set; }

        [NotMapped]
        public List<SelectListItem> branches = new List<SelectListItem>
        {
        new SelectListItem { Value = "Durban", Text = "Durban" },
        new SelectListItem { Value = "Johannesburg", Text = "Johannesburg" },
        };
    }
}

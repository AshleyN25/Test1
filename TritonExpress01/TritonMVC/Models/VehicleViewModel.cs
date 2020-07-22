using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TritonMVC.Models
{
    public class VehicleViewModel
    {
        public int ID { get; set; }
        public string branch { get; set; }
        public Nullable<int> vehicleyear { get; set; }
        public string vehiclemake { get; set; }
        public string vehiclemodel { get; set; }
        public string vehiclereg { get; set; }
        public Nullable<int> wayBillID { get; set; }

        [NotMapped]
        public List<SelectListItem> branches = new List<SelectListItem>
        {
        new SelectListItem { Value = "Durban", Text = "Durban" },
        new SelectListItem { Value = "Johannesburg", Text = "Johannesburg" },
        };
    }
}
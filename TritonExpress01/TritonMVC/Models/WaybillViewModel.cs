using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TritonMVC.Models
{
    public class WaybillViewModel
    {
        public int wayBillID { get; set; }
        [Display(Name = "Recipient Name")]
        public string RecipientName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        public string Cell { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "WayBill Information")]
        public string WayBillInfo { get; set; }
        [Display(Name = "WayBill Weight")]
        public string WayBillweight { get; set; }
        [Display(Name = "Total Items")]
        public string NumberOfParcels { get; set; }
    }
}
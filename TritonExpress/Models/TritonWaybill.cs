using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TritonExpress.Models
{
    public class TritonWaybill
    {
        [Key]
        public int wayBillID { get; set; }
        [Required]
        [Display(Name = "Vehicle")]
        public int VehicleID { get; set; }
        [Required]
        [Display(Name = "WayBill Information")]
        public string WayBillInfo { get; set; }
        [Display(Name = "WayBill Weight")]
        public string WauBillweight { get; set; }
        [Display(Name = "Total Items")]
        public string NumberOfParcels { get; set; }

        [NotMapped]
        public TritonModel triton { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TritonExpress.Models
{
    public class TritonExpressWaybill
    {
        [Key]
        public int wayBillID { get; set; }
        [Display(Name = "Recipient Name")]
        public string RecipientName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Contact Number")]
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

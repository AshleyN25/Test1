using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TritonMVC.Models
{
    public class WaybillViewModel
    {
        public int wayBillID { get; set; }
        public string RecipientName { get; set; }
        public string Address { get; set; }
        public string Cell { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string WayBillInfo { get; set; }
        public string WayBillweight { get; set; }
        public string NumberOfParcels { get; set; }
    }
}
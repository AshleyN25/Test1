//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TritonExpressVehicle
    {
        public int ID { get; set; }
        public string branch { get; set; }
        public Nullable<int> vehicleyear { get; set; }
        public string vehiclemake { get; set; }
        public string vehiclemodel { get; set; }
        public string vehiclereg { get; set; }
        public Nullable<int> wayBillID { get; set; }
    }
}

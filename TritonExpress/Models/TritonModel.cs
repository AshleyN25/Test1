using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TritonExpress.Models
{
    public class TritonModel
    {
        [Key]
        public int ID { get; set; }
        public string branch { get; set; }
        public int vehicleyear { get; set; }
        public string vehiclemake { get; set; }
        public string vehiclemodel { get; set; }
        public string vehiclereg { get; set; }
    }
}

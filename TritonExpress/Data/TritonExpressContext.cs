using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TritonExpress.Models;

namespace TritonExpress.Models
{
    public class TritonExpressContext : DbContext
    {
        public TritonExpressContext (DbContextOptions<TritonExpressContext> options)
            : base(options)
        {
        }

        public DbSet<TritonExpress.Models.TritonModel> TritonModel { get; set; }

        public DbSet<TritonExpress.Models.TritonWaybill> TritonWaybill { get; set; }

        public DbSet<TritonExpress.Models.TritonExpressVehicle> TritonExpressVehicle { get; set; }

        public DbSet<TritonExpress.Models.TritonExpressWaybill> TritonExpressWaybill { get; set; }
    }
}

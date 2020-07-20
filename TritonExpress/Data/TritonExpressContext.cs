using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TritonExpress.Models
{
    public class TritonExpressContext : DbContext
    {
        public TritonExpressContext (DbContextOptions<TritonExpressContext> options)
            : base(options)
        {
        }

        public DbSet<TritonExpress.Models.TritonModel> TritonModel { get; set; }
    }
}

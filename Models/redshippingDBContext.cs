using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedShipping.Models
{
    public class redshippingDBContext:DbContext
    {
        public redshippingDBContext(DbContextOptions<redshippingDBContext> options):base(options)
        {

        }

        public DbSet<DBShipper> Shippers { get; set; }
        public DbSet<DBShipment> Shipments { get; set; }

    }
}

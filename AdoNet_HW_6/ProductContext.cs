using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet_HW_6
{
    class ProductContext : DbContext
    {
        public ProductContext()
            : base("DbConnection")
        { }

        public DbSet<Product> products { get; set; }
    }
}

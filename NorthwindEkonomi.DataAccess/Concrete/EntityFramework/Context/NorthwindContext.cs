using NorthwindEkonomi.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEkonomi.DataAccess.Concrete.EntityFramework.Context
{
    public class NorthwindContext : DbContext //EntityFramework ile ilgili
    {
        //Aksi belirtilmezse Context ile (yani NorthwindContext) adıyla bir connection string arar.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }     
    }
}

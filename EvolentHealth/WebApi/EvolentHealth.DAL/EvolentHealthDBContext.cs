using EvolentHealth.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolentHealth.DAL
{
    public class EvolentHealthDBContext : DbContext
    {

        public EvolentHealthDBContext(): base()
        {

        }

        public DbSet<Contact> Students { get; set; }
    }
}

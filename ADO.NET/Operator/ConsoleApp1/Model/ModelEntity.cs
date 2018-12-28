using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public partial class ModelEntity : DbContext
    {
        public ModelEntity(): base("name=MCSEntities"){}

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Operator> Operator { get; set; }
        public virtual DbSet<Prefix> Prefix { get; set; }
        public virtual DbSet<AddressType> AddressType { get; set; }
    }
}

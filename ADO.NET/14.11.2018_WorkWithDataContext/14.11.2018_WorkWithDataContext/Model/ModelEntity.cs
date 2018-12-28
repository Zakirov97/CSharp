using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._11._2018_WorkWithDataContext.Model
{
    public partial class ModelEntity : DbContext
    {
        public ModelEntity() : base("name=DefaultConnection") { }

        public virtual DbSet<EquipmentHistory> EquipmentHistories { get; set; }
        public virtual DbSet<NewEquipment> NewEquipments { get; set; }
    }
}

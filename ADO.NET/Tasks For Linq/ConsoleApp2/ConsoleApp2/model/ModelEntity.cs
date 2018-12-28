namespace ConsoleApp2.model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelEntity : DbContext
    {
        public ModelEntity()
            : base("name=ModelEntity")
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<dic_Group> dic_Group { get; set; }
        public virtual DbSet<dic_Model> dic_Model { get; set; }
        public virtual DbSet<dic_Pavilion> dic_Pavilion { get; set; }
        public virtual DbSet<dic_Status> dic_Status { get; set; }
        public virtual DbSet<Timer> Timer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>()
                .Property(e => e.IP)
                .IsUnicode(false);
        }
    }
}

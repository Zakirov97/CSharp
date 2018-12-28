namespace LibraryProject.Model
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

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Library_Registered_Accounts> Library_Registered_Accounts { get; set; }
        public virtual DbSet<Library_staff> Library_staff { get; set; }
        public virtual DbSet<Library_Users> Library_Users { get; set; }
        public virtual DbSet<AssignBooks> AssignBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

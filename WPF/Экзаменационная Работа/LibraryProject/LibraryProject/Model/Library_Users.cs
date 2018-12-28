namespace LibraryProject.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Library_Users
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string UserName { get; set; }

        [Required]
        [StringLength(200)]
        public string UserAddress { get; set; }

        public int UserIdentificationNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime UserYearOfBirth { get; set; }
    }
}

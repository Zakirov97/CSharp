namespace LibraryProject.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Library_staff
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string WorkerName { get; set; }

        [Required]
        [StringLength(200)]
        public string WorkerAddress { get; set; }

        public int WorkerIdentificationNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime WorkerYearOfBirth { get; set; }
    }
}

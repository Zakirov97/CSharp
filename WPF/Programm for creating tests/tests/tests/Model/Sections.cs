namespace tests.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sections
    {
        public Sections()
        {
        }

        [Key]
        public int SectionId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


    }
}

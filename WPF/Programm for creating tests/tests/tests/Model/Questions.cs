namespace tests.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Questions
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        [StringLength(255)]
        public string QuestionContent { get; set; }

        public int SectionId { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreationDate { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Sections Sections { get; set; }
    }
}

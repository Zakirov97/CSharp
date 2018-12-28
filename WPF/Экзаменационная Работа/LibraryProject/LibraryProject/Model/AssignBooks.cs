namespace LibraryProject.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AssignBooks
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Required]
        public int Penality { get; set; }
        [Required]
        public bool Status { get; set; }

    }
}

namespace LibraryProject.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Books
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string BookName { get; set; }

        public int BookPrice { get; set; }

        [Required]
        [StringLength(200)]
        public string BookAuthor { get; set; }

        [Required]
        [StringLength(200)]
        public string BookPublishName { get; set; }

        [Column(TypeName = "date")]
        public DateTime BookYearOfPublication { get; set; }

        public int BookQuantity { get; set; }
    }
}

namespace LibraryProject.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Library_Registered_Accounts
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string AccountName { get; set; }

        [Required]
        [StringLength(200)]
        public string AccountPassword { get; set; }

        [StringLength(200)]
        public string AccountLastPassword { get; set; }

        [Required]
        public bool AccountRole { get; set; }
    }
}

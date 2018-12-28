namespace ConsoleApp2.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dic_Group
    {
        [Key]
        public int GroupId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}

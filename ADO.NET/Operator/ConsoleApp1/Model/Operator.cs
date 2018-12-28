using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    //test.Table_Operator
    //[Table("Table_Operator", Schema = "test")]
    //public class Operator
    //{
    //    //000000-00000-000000-00000-000000
    //    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public Guid OperatorId { get; set; }

    //    [Column(name: "dtCreateDate", TypeName = "date")]
    //    public DateTime? CreateDate { get; set; }

    //    [StringLength(50)]
    //    [Column("strLogo")]
    //    public string Logo { get; set; }

    //    [Column("strName")]
    //    public string Name { get; set; }

    //    //Tax  float NULL
    //    [Column("Tax")]
    //    public Nullable<double> floatTax { get; set; }

    //    [Column("bitIsActive")]
    //    public bool IsActive { get; set; }

    //    public Address Address { get; set; }
    //}


    [Table("Table_Operator", Schema = "test")]
    public class Operator
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OperatorId { get; set; }

        [Column(name: "dtCreateDate", TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [Required]
        public OperatorAdditional OperatorAdditional { get; set; }
    }

    [Table("Table_Operator", Schema = "test")]
    public class OperatorAdditional
    {
        [Key, ForeignKey("Operator")]
        public Guid OperatorId { get; set; }

        public Operator Operator { get; set; }

        [StringLength(50)]
        [Column("strLogo")]
        public string Logo { get; set; }

        [Column("strName")]
        public string Name { get; set; }

        //Tax  float NULL
        [Column("Tax")]
        public Nullable<double> floatTax { get; set; }

        [Column("bitIsActive")]
        public bool IsActive { get; set; }

        public Address Address { get; set; }
    }
}

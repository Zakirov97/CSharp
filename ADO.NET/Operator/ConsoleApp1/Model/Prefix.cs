using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    [Table("Table_Prefix", Schema = "test")]
    public class Prefix
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("intPrefixId")]
        public int PrefixId { get; set; }

        [Column("strDescription")]
        public string Description { get; set; }

        [Column("intOperatorId")]
        public int OperatorId { get; set; }
    }
}

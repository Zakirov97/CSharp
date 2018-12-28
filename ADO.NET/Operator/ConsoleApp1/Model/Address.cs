using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    [Table("Table_Address", Schema = "test")]
    public class Address
    {
        [Key]
        [ForeignKey("Operator")]
        public Guid OperatorId { get; set; }

        public Operator Operator { get; set; }

        public int AddressTypeId { get; set; }

        [Column("strContry")]
        [StringLength(255)]
        public string Contry { get; set; }

        [Column("strCity")]
        [StringLength(255)]
        public string City { get; set; }

        [Column("strHouse")]
        [StringLength(20)]
        public string House { get; set; }

        public AddressType AddressType { get; set; }
    }
}

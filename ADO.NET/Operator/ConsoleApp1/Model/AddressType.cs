using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class AddressType
    {
        [Key]
        public int AddressTypeId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public List<Address> Addresses { get; set; }
    }
}

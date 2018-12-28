using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._11._2018_WorkWithDataContext.Model
{
    [Table("newEquipment")]
    public class NewEquipment
    {
        [Key]
        [Column("intEquipmentID")]
        public int EquipmentID { get; set; }

        [Column("intGarageRoom")]
        public string GarageRoom { get; set; }

        [Column("strSerialNo")]
        public string SerialNo { get; set; }

        public EquipmentHistory EquipmentHistory { get; set; }
    }
}

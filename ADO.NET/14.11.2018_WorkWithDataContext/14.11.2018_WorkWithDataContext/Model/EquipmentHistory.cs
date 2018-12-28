using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._11._2018_WorkWithDataContext.Model
{
    [Table("TableEquipmentHistory")]
    public class EquipmentHistory
    {
        [Key]
        [ForeignKey("NewEquipment")]
        [Column("intEquipmentHistoryId")]
        public int EquipmentHistoryId { get; set; }

        [Column("intTypeHistory")]
        public int? TypeHistory { get; set; }

        [Column("dStartDate")]
        public DateTime? StartDate { get; set; }

        [Column("dEndDate")]
        public DateTime? EndDate { get; set; }

        [Column("intDaysCount")]
        public int? DaysCount { get; set; }

        [Column("intStatys")]
        public int? Statys { get; set; }

        public NewEquipment NewEquipment { get; set; }
    }
}

namespace DAL.dll.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TablesLocation")]
    public partial class TablesLocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TablesLocation()
        {
            newEquipment = new HashSet<newEquipment>();
        }

        [Key]
        public int intLocationId { get; set; }

        [StringLength(500)]
        public string strLocationName { get; set; }

        public int? intMajorLocationID { get; set; }

        public double? floatWageStatements { get; set; }

        public int? intWageStatementsCurrency { get; set; }

        public double? floatAdministrativeExpenses { get; set; }

        public int? intAdministrativeExpensesCurrency { get; set; }

        [StringLength(500)]
        public string strAddressName { get; set; }

        [StringLength(500)]
        public string strAddressName3 { get; set; }

        [StringLength(50)]
        public string strAddressName5 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<newEquipment> newEquipment { get; set; }
    }
}

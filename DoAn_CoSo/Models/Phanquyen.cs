namespace DoAn_CoSo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phanquyen")]
    public partial class Phanquyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phanquyen()
        {
            Nguoidung = new HashSet<Nguoidung>();
        }
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDQuyen { get; set; }

        [StringLength(20)]
        public string Tenquyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nguoidung> Nguoidung { get; set; }
    }
}

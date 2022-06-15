namespace DoAn_CoSo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nhaxuatban")]
    public partial class Nhaxuatban
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nhaxuatban()
        {
            Sanpham = new HashSet<Sanpham>();
        }
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Manxb { get; set; }

        [StringLength(50)]
        public string Tennxb { get; set; }

        [StringLength(50)]
        public string Diachi { get; set; }

        [StringLength(10)]
        public string Sdt { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sanpham> Sanpham { get; set; }
    }
}

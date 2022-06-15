namespace DoAn_CoSo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Loaisach")]
    public partial class Loaisach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Loaisach()
        {
            Sanpham = new HashSet<Sanpham>();
        }
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Maloai { get; set; }

        [StringLength(50)]
        public string Tenloai { get; set; }

        [StringLength(50)]
        public string Linhvuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sanpham> Sanpham { get; set; }
    }
}

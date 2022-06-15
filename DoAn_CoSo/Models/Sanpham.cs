namespace DoAn_CoSo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sanpham")]
    public partial class Sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sanpham()
        {
            Chitietdonhang = new HashSet<Chitietdonhang>();
        }
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Masach { get; set; }

        [StringLength(50)]
        public string Tensach { get; set; }

        public decimal? Giatien { get; set; }

        public int? Soluong { get; set; }

        [Column(TypeName = "ntext")]
        public string Mota { get; set; }

        [StringLength(50)]
        public string Theloai { get; set; }

        [StringLength(50)]
        public string Tacgia { get; set; }

        //public bool? Sanphammoi { get; set; }

        [StringLength(50)]
        public string Hinhanh { get; set; }
       
        public int? Manxb { get; set; }
        public int? Maloai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietdonhang> Chitietdonhang { get; set; }

        public virtual Nhaxuatban Nhaxuatban { get; set; }

        public virtual Loaisach Loaisach { get; set; }
    }
}

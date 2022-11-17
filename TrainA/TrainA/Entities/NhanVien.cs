using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainA.Entities
{
    public class NhanVien
    {
        public NhanVien()
        {
            DuAns = new HashSet<DuAn>();
            KiNangs = new HashSet<KiNang>();
            KienThucs = new HashSet<KienThuc>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
        public int MaViTri { get; set; }
        public virtual ViTri VT { get; set; }
        public int MaPhongBan { get; set; }
        public virtual PhongBan PB { get; set; }
        public virtual ICollection<DuAn> DuAns { get; set; }
        public virtual ICollection<KiNang> KiNangs { get; set; }
        public virtual ICollection<KienThuc> KienThucs { get; set; }

    }
}

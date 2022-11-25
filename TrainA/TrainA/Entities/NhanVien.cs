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
            KiNangs = new HashSet<KiNang>();
            KienThucs = new HashSet<KienThuc>();
            DuAns = new HashSet<DuAn>();
            LopHocs = new HashSet<NhanVienLopHoc>();
            KhoaHocs = new HashSet<NhanVienKhoaHoc>();
            PhanHois = new HashSet<PhanHoi>();

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
        public int MaViTri { get; set; }
        public int MaPhongBan { get; set; }
        public virtual ICollection<KiNang> KiNangs { get; set; }
        public virtual ICollection<KienThuc> KienThucs { get; set; }
        public virtual ICollection<DuAn> DuAns { get; set; }
        public virtual ICollection<NhanVienLopHoc> LopHocs { get; set; }
        public virtual ICollection<NhanVienKhoaHoc> KhoaHocs { get; set; }
        public virtual ICollection<PhanHoi> PhanHois { get; set; }

    }
}

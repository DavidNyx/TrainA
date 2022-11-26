using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainA.Entities
{
    public class KhoaHoc
    {
        public KhoaHoc()
        {
            NhanViens = new HashSet<NhanVienKhoaHoc>();
            LopHocs = new HashSet<LopHocKhoaHoc>();
            ViTris = new HashSet<ViTri>();
            KiNangs = new HashSet<KiNang>();
            KienThucs = new HashSet<KienThuc>();
            NoiDungs = new HashSet<NoiDung>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string MucTieu { get; set; }
        public bool HinhThuc { get; set; }
        public string GhiChu { get; set; }
        public virtual ICollection<NhanVienKhoaHoc> NhanViens { get; set; }
        public virtual ICollection<LopHocKhoaHoc> LopHocs { get; set; }
        public virtual ICollection<ViTri> ViTris { get; set; }
        public virtual ICollection<KiNang> KiNangs { get; set; }
        public virtual ICollection<KienThuc> KienThucs { get; set; }
        public virtual ICollection<NoiDung> NoiDungs { get; set; }

    }
}

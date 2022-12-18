using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainA.Entities
{
    public class KiNang
    {
        public KiNang()
        {
            NhanViens = new HashSet<NhanVien>();
            PhongBans = new HashSet<PhongBan>();
            DuAns = new HashSet<DuAn>();
            ViTris = new HashSet<ViTri>();
            KhoaHocs = new HashSet<KhoaHoc>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaKN { get; set; }
        public string TenKN { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
        public virtual ICollection<PhongBan> PhongBans { get; set; }
        public virtual ICollection<DuAn> DuAns { get; set; }
        public virtual ICollection<ViTri> ViTris { get; set; }
        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }

    }
}

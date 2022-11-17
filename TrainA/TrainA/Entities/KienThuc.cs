using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainA.Entities
{
    public class KienThuc
    {
        public KienThuc()
        {
            NhanViens = new HashSet<NhanVien>();
            PhongBans = new HashSet<PhongBan>();
            DuAns = new HashSet<DuAn>();
            ViTris = new HashSet<ViTri>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaKT { get; set; }
        public string TenKT { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
        public virtual ICollection<PhongBan> PhongBans { get; set; }
        public virtual ICollection<DuAn> DuAns { get; set; }
        public virtual ICollection<ViTri> ViTris { get; set; }
    }
}

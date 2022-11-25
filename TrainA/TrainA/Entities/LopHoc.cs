using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainA.Entities
{
    public class LopHoc
    {
        public LopHoc()
        {
            NhanViens = new HashSet<NhanVienLopHoc>();
            KhoaHocs = new HashSet<LopHocKhoaHoc>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaLH { get; set; }
        public string TenLH { get; set; }
        public int MaViTri { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public virtual ICollection<NhanVienLopHoc> NhanViens { get; set; }
        public virtual ICollection<LopHocKhoaHoc> KhoaHocs { get; set; }

    }
}

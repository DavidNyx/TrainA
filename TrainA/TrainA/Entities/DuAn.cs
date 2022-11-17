using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainA.Entities
{
    public class DuAn
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaDA { get; set; }
        public string TenDA { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayDatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}

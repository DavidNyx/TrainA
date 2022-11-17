using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainA.Entities
{
    public class PhongBan
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaPB { get; set; }
        public string TenPB { get; set; }
        public string MoTa { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}

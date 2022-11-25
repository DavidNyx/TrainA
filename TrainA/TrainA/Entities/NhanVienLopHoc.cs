using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainA.Entities
{
    public class NhanVienLopHoc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaNVLH { get; set; }
        public int MaNV { get; set; }
        public int MaLH { get; set; }
        public bool DanhGia { get; set; }
    }
}

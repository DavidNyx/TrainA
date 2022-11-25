using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainA.Entities
{
    public class NhanVienKhoaHoc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaNVKH { get; set; }
        public int MaNV { get; set; }
        public int MaKH { get; set; }
        public bool DanhGia { get; set; }
    }
}

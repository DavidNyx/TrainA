using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainA.Entities
{
    public class LopHocKhoaHoc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaLHKH { get; set; }
        public int MaLH { get; set; }
        public int MaKH { get; set; }
        public float CotDiem1 { get; set; }
        public float CotDiem2 { get; set; }
        public float CotDiem3 { get; set; }
        public float CotDiem4 { get; set; }
        public float CotDiem5 { get; set; }
        public float CotDiem6 { get; set; }
        public float CotDiem7 { get; set; }
        public float CotDiem8 { get; set; }
        public float CotDiem9 { get; set; }
        public float CotDiem10 { get; set; }
        public float CotDiemThi { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainA.Entities
{
    public class TaiLieu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaTL { get; set; }
        public string TenTL { get; set; }
        public string NoiDungTaiLieu { get; set; }
        public int MaNoiDung { get; set; }
    }
}

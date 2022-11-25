using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainA.Entities
{
    public class PhanHoi
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaPH { get; set; }
        public string TenPH { get; set; }
        public string NoiDungPhanHoi { get; set; }
        public int MaNoiDung { get; set; }
        public int MaTrainee { get; set; }
    }
}

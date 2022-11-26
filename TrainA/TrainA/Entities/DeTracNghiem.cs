using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainA.Entities
{
    public class DeTracNghiem
    {
        public DeTracNghiem()
        {
            DeBais = new HashSet<DeBai>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaDTN { get; set; }
        public string CauHoiTracNghiem { get; set; }
        public string DapAn1 { get; set; }
        public string DapAn2 { get; set; }
        public string DapAn3 { get; set; }
        public string DapAn4 { get; set; }
        public int DapAnDung { get; set; }
        public virtual ICollection<DeBai> DeBais { get; set; }

    }
}

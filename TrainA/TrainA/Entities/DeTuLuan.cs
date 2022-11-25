using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainA.Entities
{
    public class DeTuLuan
    {
        public DeTuLuan()
        {
            DeBais = new HashSet<DeBai>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaDTL { get; set; }
        public string CauHoiTuLuan { get; set; }
        public string DapAn { get; set; }
        public virtual ICollection<DeBai> DeBais { get; set; }

    }
}

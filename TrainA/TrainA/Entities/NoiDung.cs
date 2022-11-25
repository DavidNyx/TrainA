using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainA.Entities
{
    public class NoiDung
    {
        public NoiDung()
        {
            PhanHois = new HashSet<PhanHoi>();
            TaiLieus = new HashSet<TaiLieu>();
            DeBais = new HashSet<DeBai>();

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaND { get; set; }
        public string TenND { get; set; }
        public int ThoiGian { get; set; }
        public int MaKhoaHoc { get; set; }
        public virtual ICollection<PhanHoi> PhanHois { get; set; }
        public virtual ICollection<TaiLieu> TaiLieus { get; set; }
        public virtual ICollection<DeBai> DeBais { get; set; }

    }
}

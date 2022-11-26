using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainA.Entities
{
    public class DeBai
    {
        public DeBai()
        {
            NoiDungs = new HashSet<NoiDung>();
            DeTuLuans = new HashSet<DeTuLuan>();
            DeTracNghiems = new HashSet<DeTracNghiem>();

        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MaDB { get; set; }
        public string TenDB { get; set; }
        public bool LoaiDB { get; set; }
        public virtual ICollection<NoiDung> NoiDungs { get; set; }
        public virtual ICollection<DeTuLuan> DeTuLuans { get; set; }
        public virtual ICollection<DeTracNghiem> DeTracNghiems { get; set; }

    }
}

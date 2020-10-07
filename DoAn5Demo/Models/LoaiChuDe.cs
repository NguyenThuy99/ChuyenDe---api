using System;
using System.Collections.Generic;

namespace DoAn5Demo.Models
{
    public partial class LoaiChuDe
    {
        public LoaiChuDe()
        {
            ChuDe = new HashSet<ChuDe>();
        }

        public int Id { get; set; }
        public string Tenchude { get; set; }

        public virtual ICollection<ChuDe> ChuDe { get; set; }
    }
}

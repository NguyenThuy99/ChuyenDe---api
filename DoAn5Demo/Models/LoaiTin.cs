using System;
using System.Collections.Generic;

namespace DoAn5Demo.Models
{
    public partial class LoaiTin
    {
        public LoaiTin()
        {
            TinTuc = new HashSet<TinTuc>();
        }

        public int Id { get; set; }
        public string Tenloai { get; set; }

        public virtual ICollection<TinTuc> TinTuc { get; set; }
    }
}

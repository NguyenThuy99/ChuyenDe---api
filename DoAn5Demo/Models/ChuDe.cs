using System;
using System.Collections.Generic;

namespace DoAn5Demo.Models
{
    public partial class ChuDe
    {
        public int Id { get; set; }
        public int? Idcd { get; set; }
        public string Tieude { get; set; }
        public string Noidung { get; set; }
        public DateTime? Ngaydang { get; set; }

        public virtual LoaiChuDe IdcdNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DoAn5Demo.Models
{
    public partial class TinTuc
    {
        public int Id { get; set; }
        public int? Idloai { get; set; }
        public string Tieude { get; set; }
        public string Hinhanh { get; set; }
        public string Mota { get; set; }
        public DateTime? Ngaydang { get; set; }
        public string Noidung { get; set; }

        public virtual LoaiTin IdloaiNavigation { get; set; }
    }
}

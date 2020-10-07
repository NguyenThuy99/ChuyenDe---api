using System;
using System.Collections.Generic;

namespace DoAn5Demo.Models
{
    public partial class QuangCao
    {
        public int Id { get; set; }
        public int? Idqc { get; set; }
        public string Tieude { get; set; }
        public string Video { get; set; }

        public virtual LoaiQuangCao IdqcNavigation { get; set; }
    }
}

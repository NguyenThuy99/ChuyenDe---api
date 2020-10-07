using System;
using System.Collections.Generic;

namespace DoAn5Demo.Models
{
    public partial class LoaiQuangCao
    {
        public LoaiQuangCao()
        {
            QuangCao = new HashSet<QuangCao>();
        }

        public int Id { get; set; }
        public string Tenquangcao { get; set; }

        public virtual ICollection<QuangCao> QuangCao { get; set; }
    }
}

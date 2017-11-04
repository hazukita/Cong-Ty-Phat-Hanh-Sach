using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class phieuthu
    {
        public int id { get; set; }
        public DateTime ngaylap { get; set; }
        public string nguoithu { get; set; }
        public int id_phieuxuat { get; set; }
        public decimal? thanhtoan { get; set; }
        public int id_daily { get; set; }
    }
}

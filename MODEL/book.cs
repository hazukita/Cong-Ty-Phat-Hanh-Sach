using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class book
    {
        public int ma { get; set; }
        public string ten { get; set; }
        public string mota { get; set; }
        public decimal gianhap { get; set; }
        public decimal giaxuat { get; set; }
        public int? id_danhmuc { get; set; }
        public int? id_nxb { get; set; }
        public int sl { get; set; }
        public category cat { get; set; }
        public nxb nhaxb { get; set; }
        public byte[] img { get; set; }
    }
    public class bookSearch
    {
        public int? ma { get; set; }
        public string ten { get; set; }
        public string mota { get; set; }
        public decimal? gianhap { get; set; }
        public decimal? giaxuat { get; set; }
        public decimal? gianhapden { get; set; }
        public decimal? giaxuatden { get; set; }
        public int? id_danhmuc { get; set; }
        public int? id_nxb { get; set; }
    }
}

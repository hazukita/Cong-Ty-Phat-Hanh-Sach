using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Chitietphieuxuat
    {
        public int masach { get; set; }
        public int mapn { get; set; }
        public int sl { get; set; }
        public decimal gia { get; set; }
        public sach sach { get; set; }
    }
    public class sach { 
        public int id { get; set; }
        public string name { get; set; }
    }
    public class chitet
    {
        public int id { get; set; }
        public int? sl { get; set; }
    }
}

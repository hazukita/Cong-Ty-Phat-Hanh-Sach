using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class thonhkesoluongtonkho
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal gia { get; set; }
        public decimal gianhap { get; set; }
        public nxb nxb { get; set; }
        public int? slht { get; set; }
        public int? slx { get; set; }
        public int? sln { get; set; }
        public int? sltk { get; set; }
    }
    public class test { 
        public int idsach { get; set; }
        public int? sltt { get; set; }
        public int? slx { get; set; }
        public int? sln { get; set; }
        public int? slttg { get; set; }
               
    }
    public class thongkecongnodl
    {
        public decimal tongno { get; set; }
        public decimal tongthu { get; set; }
        public decimal tongcong { get; set; }
        public List<chitietthongkecongnodl> ctg { get; set; }
    }
    public class chitietthongkecongnodl
    {
        public int id { get; set; }
        public DateTime datecreate { get; set; }
        public string nguoinhan { get; set; }
        public string nguoigiao { get; set; }
        public decimal? tienno { get; set; }
        public decimal? tientra { get; set; }
        public decimal tongtien { get; set; }
        public daily dl { get; set; }

    }
    public class thongketientrachonxb
    {
        public int id { get; set; }
        public DateTime datecreate { get; set; }
        public string nguoinhan { get; set; }
        public string nguoigiao { get; set; }
        public decimal? tienno { get; set; }
        public decimal? tientra { get; set; }
        public decimal tongtien { get; set; }
        public nxb nxb { get; set; }
    }
}

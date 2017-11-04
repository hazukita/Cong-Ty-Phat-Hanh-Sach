using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
   public class phieunhap
    {
        [DisplayName("Mã")]
        public int id { get; set; }
        [DisplayName("Người tạo")]
        public string nguoitao { get; set; }
        [DisplayName("Người giao")]
        public string nguoigia { get; set; }
        [DisplayName("Nhà xb")]
        public nxb nxb { get; set; }
        [DisplayName("Nhà xb")]
        public int id_nxb { get; set; }
        [DisplayName("Tổng tiền")]
        public decimal giatri { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
        [DisplayName("Ngày nhập")]
        public DateTime ngayxuat { get; set; }
        public List<Chitietphieunhap> chitiet { get; set; }
        public List<phieuchi> phieuchi { get; set; }
    }
    public class phieunhapsearch { 
        public int? id { get; set; }
        public string nguoinhan { get; set; }
        public string nguoigiao { get; set; }
        public DateTime? ngaytu { get; set; }
        public DateTime? ngayden { get; set; }
        public decimal? tientu { get; set; }
        public decimal? tienden { get; set; }
        public int? id_nxb { get; set; }
    }
}

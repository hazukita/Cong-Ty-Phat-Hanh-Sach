using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class phieuxuat
    {
        [DisplayName("Mã")]
        public int id { get; set; }
        [DisplayName("Người tạo")]
        public string nguoitao { get; set; }
        [DisplayName("Người giao")]
        public string nguoigia { get; set; }
        [DisplayName("Nhà xb")]
        public daily dl { get; set; }
        [DisplayName("Đại lý")]
        public int id_dl { get; set; }
        [DisplayName("Tổng tiền")]
        public decimal giatri { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
        [DisplayName("Ngày xuất")]
        public DateTime ngayxuat { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
              ApplyFormatInEditMode = true)]
        [DisplayName("Hạn nợ")]
        public DateTime? hanthanhtoan { get; set; }
        [DisplayName("Thanh toán")]
        public decimal? thanhtoan { get; set; }
        public List<Chitietphieuxuat> chitiet { get; set; }
        public List<phieuthu> phieuthu { get; set; }
    }
    public class phieuxuatSearch
    {
    public int? id { get; set; }
    public string nguoinhan { get; set; }
    public string nguoigiao { get; set; }
    public DateTime? ngaytu { get; set; }
    public DateTime? ngayden { get; set; }
    public decimal? tientu { get; set; }
    public decimal? tienden { get; set; }
    public int? id_dl { get; set; }
}
}

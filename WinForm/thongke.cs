using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODEL;
using BUS;

namespace WinForm
{
    public partial class thongke : Form
    {
        public thongke()
        {
            InitializeComponent();
          


        }

        private void button1_Click(object sender, EventArgs e)
        {

            //tb_trang.Text = "1";
            DataTable table = new DataTable();
            int stt = 0;
            table.Columns.Add("STT", typeof(int));
            table.Columns.Add("Ma", typeof(int));
            table.Columns.Add("Tên", typeof(string));
            table.Columns.Add("NXB", typeof(string));
            table.Columns.Add("Giá nhập", typeof(decimal));
            table.Columns.Add("Giá xuất", typeof(decimal));
            table.Columns.Add("SL.Hiện tại", typeof(int));
            table.Columns.Add("SL.Nhập", typeof(int));
            table.Columns.Add("SL.Xuất", typeof(int));
            table.Columns.Add("SL.T.Kho", typeof(int));
            var model = thongkeService.tksltk(dtp_nt.Value, dtp_nd.Value);
            foreach (var item in model)
            {
                stt++;
                table.Rows.Add(stt, item.id, item.name, item.nxb.name, item.gia, item.gianhap,item.slht,item.sln, item.slx,item.sltk);
            }
            dgv_tk.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            int stt = 0;
            table.Columns.Add("STT", typeof(int));
            table.Columns.Add("Ma", typeof(int));
            table.Columns.Add("Ngày tạo", typeof(DateTime));
            table.Columns.Add("Đại lý", typeof(string));
            table.Columns.Add("Nợ", typeof(decimal));
            table.Columns.Add("Trả", typeof(decimal));
            table.Columns.Add("T.Tiền", typeof(int));
            table.Columns.Add("N.giao", typeof(string));
            table.Columns.Add("N.nhận", typeof(string));

            var model = thongkeService.tkcndl(dtp_nt.Value, dtp_nd.Value).ctg;
            foreach (var item in model)
            {
                stt++;
                table.Rows.Add(stt, item.id, item.datecreate, item.dl.name, item.tienno, item.tientra, item.tongtien, item.nguoigiao, item.nguoinhan);
            }
            dgv_tk.DataSource = table;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            int stt = 0;
            table.Columns.Add("STT", typeof(int));
            table.Columns.Add("Ma", typeof(int));
            table.Columns.Add("Ngày tạo", typeof(DateTime));
            table.Columns.Add("Nxb",typeof(string));
            table.Columns.Add("Nợ", typeof(decimal));
            table.Columns.Add("Trả", typeof(decimal));
            table.Columns.Add("T.Tiền", typeof(int));
            table.Columns.Add("N.giao", typeof(string));
            table.Columns.Add("N.nhận", typeof(string));

            var model = thongkeService.tkcnnxb(dtp_nt.Value, dtp_nd.Value);
            foreach (var item in model)
            {
                stt++;
                table.Rows.Add(stt, item.id, item.datecreate, item.nxb.name, item.tienno, item.tientra, item.tongtien, item.nguoigiao, item.nguoinhan);
            }
            dgv_tk.DataSource = table;
        }
    }
   
}

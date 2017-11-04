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
    public partial class FormDaiLy : Form
    {
        public FormDaiLy()
        {
            InitializeComponent();
            dailyForm.loadFormSach(dataGridView1);
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            string ten = "";
            string diachi = "";
            decimal mucno = 0;
            ten = tb_ten.Text.Trim();
            diachi = tb_diachi.Text.Trim();
            try
            {
                mucno = Convert.ToDecimal(tb_mucno.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mức nợ phải nhấp số");
            }

            daily dl = new daily();
            dl.name = ten;
            dl.address = diachi;
            dl.mucno = mucno;
            bool rs = DailyService.Insert(dl);
            if (rs)
            {
                MessageBox.Show("Thành công");
                dailyForm.loadFormSach(dataGridView1);
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ma = Convert.ToInt16(tb_ma.Text);
            string ten = "";
            string diachi = "";
            decimal mucno = 0;
            ten = tb_ten.Text.Trim();
            diachi = tb_diachi.Text.Trim();
            try
            {
                mucno = Convert.ToDecimal(tb_mucno.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mức nợ phải nhấp số");
            }

            daily dl = new daily();
            dl.id = ma;
            dl.name = ten;
            dl.address = diachi;
            dl.mucno = mucno;
            bool rs = DailyService.Update(dl);
            if (rs)
            {
                MessageBox.Show("Thành công");
                dailyForm.loadFormSach(dataGridView1);
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string i = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int id = Convert.ToInt16(i);
            var res = DailyService.GetBookById(id);
            tb_ma.Text = res.id.ToString();
            tb_ten.Text = res.name;
            tb_diachi.Text = res.address;
            tb_mucno.Text = res.mucno.ToString();
        }
    }
}

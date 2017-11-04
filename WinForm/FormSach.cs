using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using MODEL;
using System.IO;

namespace WinForm
{
    public partial class FormSach : Form
    {     
        private byte[] img;
        public FormSach()
        {
            InitializeComponent();
            loadSach();
        }
        public void loadSach(int page= 1)
        {
            tb_trang.Text = "1";
            DataTable table = new DataTable();
            int stt = 0;
            table.Columns.Add("STT", typeof(int));
            table.Columns.Add("Ma", typeof(int));
            table.Columns.Add("Tên", typeof(string));
            table.Columns.Add("Số Lượng", typeof(int));
            table.Columns.Add("Giá nhập", typeof(decimal));
            table.Columns.Add("Giá xuất", typeof(decimal));
            table.Columns.Add("NXB", typeof(string));
            table.Columns.Add("Danh mục", typeof(string));
            var books = SachService.GetAllBooks(page);
            foreach (var item in books)
            {
                stt++;
                table.Rows.Add(stt, item.ma, item.ten, item.sl, item.gianhap, item.giaxuat, item.nhaxb.name, item.cat.name);
            }
            dgv_sach.DataSource = table;
        }

        public void loadSachformsearch(bookSearch bs,int page = 1)
        {
            
            tb_trang.Text = "1";
            DataTable table = new DataTable();
            int stt = 0;
            table.Columns.Add("STT", typeof(int));
            table.Columns.Add("Ma", typeof(int));
            table.Columns.Add("Tên", typeof(string));
            table.Columns.Add("Số Lượng", typeof(int));
            table.Columns.Add("Giá nhập", typeof(decimal));
            table.Columns.Add("Giá xuất", typeof(decimal));
            table.Columns.Add("NXB", typeof(string));
            table.Columns.Add("Danh mục", typeof(string));
            var books = SachService.GetBookByobj(bs,page);
            foreach (var item in books)
            {
                stt++;
                table.Rows.Add(stt, item.ma, item.ten,item.sl, item.gianhap, item.giaxuat, item.nhaxb.name, item.cat.name);
            }
            dgv_sach.DataSource = table;
        }
        public void loadDM()
        {
            cb_danhmuc.DataSource = DanhmucService.GetAllBooks();
            cb_danhmuc.ValueMember = "id";
            cb_danhmuc.DisplayMember = "name";
        }
        public void loadNxb()
        {
            cb_nhaxb.DataSource = NxbServeic.GetAll();
            cb_nhaxb.ValueMember = "id";
            cb_nhaxb.DisplayMember = "name";
        }
        private void FormSach_Load(object sender, EventArgs e)
        {
            loadDM();
            loadSach();
            loadNxb();
            bt_timkiem.Enabled = false;
            bt_xoa.Enabled = false;
            bt_capnhat.Enabled = false;
            tb_gianhapden.Enabled = false;
            tb_giaxuatden.Enabled = false;
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            return ms.ToArray();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            //For any other formats
            of.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (of.ShowDialog() == DialogResult.OK)
            {
                txt_nameimg.Text = of.FileName;
                pictureBox1.ImageLocation = of.FileName;
                Image Img = Image.FromFile(of.FileName);
                byte[] arr = new byte[50000000];
                arr = imageToByteArray(Img);
                img = arr;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            string ten = "";
            if (tb_ten.TextLength > 0)
            {
                ten = tb_ten.Text;
            }
            else
            {
                MessageBox.Show("Tên không được trống");
            }
            decimal gianhap = 0;
            decimal giaxuat = 0;
            try
            {
                gianhap = Convert.ToDecimal(tb_gianhap.Text.Trim());
                giaxuat = Convert.ToDecimal(tb_giaxuat.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("giá phai nhập số");
            }
            string mota = "";
            if(tb_mota.TextLength > 0){
                mota = tb_mota.Text.Trim();
            }
            int id_danhmuc = Convert.ToInt16(cb_danhmuc.SelectedValue);
            int id_nxb = Convert.ToInt16(cb_nhaxb.SelectedValue);
            book b = new book();
            b.id_danhmuc = id_danhmuc;
            b.id_nxb = id_nxb;
            b.ten = ten;
            b.mota = mota;
            b.gianhap = gianhap;
            b.giaxuat = giaxuat;
            b.img = img;
            bool kq =   SachService.InsertBook(b);
            if (kq)
            {
                MessageBox.Show("Tạo thành công");
                loadSach();
            }
            else
            {
                MessageBox.Show("Tạo thất bại");
            }
            

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void dgv_sach_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bt_timkiem.Enabled = false;
            bt_them.Enabled = true;
            bt_capnhat.Enabled = true;
            bt_xoa.Enabled = true;
            bt_capnhat.Enabled = true;
            tb_gianhapden.Enabled = false;
            tb_giaxuatden.Enabled = false;
            tb_ma.Enabled = false;
            string i = dgv_sach.Rows[e.RowIndex].Cells[1].Value.ToString();
            int id = Convert.ToInt16(i);
            var res = SachService.GetBookById(id);
            tb_ma.Text = res.ma.ToString();
            tb_ten.Text = res.ten;
            tb_mota.Text = res.mota;
            tb_gianhap.Text = res.gianhap.ToString();
            tb_giaxuat.Text = res.giaxuat.ToString();
            cb_nhaxb.SelectedValue = res.nhaxb.id;
            cb_danhmuc.SelectedValue = res.cat.id;
            if (res.img !=null)
            {
                img = res.img;
                pictureBox1.Image = byteArrayToImage(res.img);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }

        private void bt_capnhat_Click(object sender, EventArgs e)
        {
            string ten = "";
            if (tb_ten.TextLength > 0)
            {
                ten = tb_ten.Text;
            }
            else
            {
                MessageBox.Show("Tên không được trống");
            }
            decimal gianhap = 0;
            decimal giaxuat = 0;
            try
            {
                gianhap = Convert.ToDecimal(tb_gianhap.Text.Trim());
                giaxuat = Convert.ToDecimal(tb_giaxuat.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("giá phai nhập số");
            }
            string mota = "";
            if (tb_mota.TextLength > 0)
            {
                mota = tb_mota.Text.Trim();
            }
            int id_danhmuc = Convert.ToInt16(cb_danhmuc.SelectedValue);
            int id_nxb = Convert.ToInt16(cb_nhaxb.SelectedValue);
            book b = new book();
            b.ma = Convert.ToInt16(tb_ma.Text.Trim());
            b.id_danhmuc = id_danhmuc;
            b.id_nxb = id_nxb;
            b.ten = ten;
            b.mota = mota;
            b.gianhap = gianhap;
            b.giaxuat = giaxuat;
            b.img = img;
            bool kq = SachService.UpdateBook(b);
            if (kq)
            {
                MessageBox.Show("cập nhật thành công");
                loadSach();
            }
            else
            {
                MessageBox.Show("cập nhật thất bại");
            }
        }
        public void clear()
        {
            tb_ma.Text ="";
            tb_ten.Text ="";
            tb_mota.Text ="";
            tb_gianhap.Text ="";
            tb_giaxuat.Text = "";
            loadDM();
            loadSach();
            loadNxb();
            img = null;
            txt_nameimg.Text = "";
            pictureBox1.Image = null;
            bt_timkiem.Enabled = false;
            bt_xoa.Enabled = false;
            bt_capnhat.Enabled = false;
            tb_gianhapden.Enabled = false;
            tb_giaxuatden.Enabled = false;
        }
        private void bt_xoa_Click(object sender, EventArgs e)
        {
            DialogResult myResult;
            myResult = MessageBox.Show("Are you really delete the item?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (myResult == DialogResult.OK)
            {
                int id = Convert.ToInt16(tb_ma.Text);
                var rs = SachService.DeleteBook(id);
                if (rs)
                {
                    MessageBox.Show("Xóa thành công");

                    clear();
                }
                else
                {
                    MessageBox.Show("Xóa nhật thất bại");
                }
            }
        }
        
        private void bt_lammoi_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                bt_timkiem.Enabled = true;
                tb_gianhapden.Enabled = true;
                tb_giaxuatden.Enabled = true;
                tb_ma.Enabled = true;
                bt_them.Enabled = false;
                bt_xoa.Enabled = false;
                bt_capnhat.Enabled = false;
            }
            else
            {
                bt_timkiem.Enabled = false;
                bt_them.Enabled = true;
                bt_capnhat.Enabled = true;
                bt_xoa.Enabled = true;
                bt_capnhat.Enabled = true;
                tb_gianhapden.Enabled = false;
                tb_giaxuatden.Enabled = false;
                tb_ma.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int current = 1;
            try
            {
                current = Convert.ToInt16(tb_trang.Text);
                current++;
                loadSach(current);
                tb_trang.Text = current.ToString();
            }
            catch (Exception ex)
            {
                loadSach(current);
                tb_trang.Text = current.ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            int current = 1;
            try
            {
                current = Convert.ToInt16(tb_trang.Text);
                current--;
                if(current < 1)
                {
                    current = 1;
                }
                loadSach(current);
                tb_trang.Text = current.ToString();
            }
            catch (Exception ex)
            {
                loadSach(current);
                tb_trang.Text = current.ToString();
            }
        }

        private void bt_timkiem_Click(object sender, EventArgs e)
        {
            bookSearch bs = new bookSearch();
            if (tb_ten.TextLength > 0)
            {
                bs.ten = tb_ten.Text;
            }
          
            if (tb_ma.TextLength > 0)
            {
                try
                {
                    bs.ma = Convert.ToInt16(tb_ma.Text.Trim());
                }
                catch(Exception ex)
                {

                }
            }           
            try
            {
                bs.gianhap = Convert.ToDecimal(tb_gianhap.Text.Trim());
                bs.giaxuat = Convert.ToDecimal(tb_giaxuat.Text.Trim());
                bs.gianhapden = Convert.ToDecimal(tb_gianhapden.Text.Trim());
                bs.giaxuatden = Convert.ToDecimal(tb_giaxuatden.Text.Trim());
            }
            catch (Exception ex)
            {
               
            }
            try
            {
                bs.gianhap = Convert.ToDecimal(tb_gianhap.Text.Trim());
                bs.giaxuat = Convert.ToDecimal(tb_giaxuat.Text.Trim());
                bs.gianhapden = Convert.ToDecimal(tb_gianhapden.Text.Trim());
                bs.giaxuatden = Convert.ToDecimal(tb_giaxuatden.Text.Trim());
            }
            catch (Exception ex)
            {

            }
            try
            {
                bs.gianhap = Convert.ToDecimal(tb_gianhap.Text.Trim());
               
            }
            catch (Exception ex)
            {

            }
            try
            {        
                bs.giaxuat = Convert.ToDecimal(tb_giaxuat.Text.Trim());     
            }
            catch (Exception ex)
            {
            }
            try
            { 
                bs.gianhapden = Convert.ToDecimal(tb_gianhapden.Text.Trim()); 
            }
            catch (Exception ex)
            {

            }
            try
            {
                bs.giaxuatden = Convert.ToDecimal(tb_giaxuatden.Text.Trim());
            }
            catch (Exception ex)
            {

            }
            if (tb_mota.TextLength > 0)
            {
                bs.mota = tb_mota.Text;
            }
            bs.id_danhmuc = Convert.ToInt16(cb_danhmuc.SelectedValue);
            bs.id_nxb = Convert.ToInt16(cb_nhaxb.SelectedValue);

            loadSachformsearch(bs);

        }

        private void bt_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

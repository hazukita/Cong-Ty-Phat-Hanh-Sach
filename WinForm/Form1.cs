using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            thongke tk = new thongke();
            tk.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSach tk = new FormSach();
            tk.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormDaiLy tk = new FormDaiLy();
            tk.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

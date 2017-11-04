using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using MODEL;
using System.Data;

namespace WinForm
{
    public static class dailyForm 
    {
        public static void loadFormSach(DataGridView gv)
        {
            int stt = 0;
            DataTable table = new DataTable();
            table.Columns.Add("STT", typeof(int));
            table.Columns.Add("Ma", typeof(int));
            table.Columns.Add("Tên", typeof(string));
            table.Columns.Add("Địa chỉ", typeof(string));
            table.Columns.Add("Mức nợ", typeof(decimal));
            var books = DailyService.GetAll();
            foreach (var item in books)
            {
                stt++;
                table.Rows.Add(stt, item.id, item.name, item.address, item.mucno);
            }
            gv.DataSource = table;
        }
        
    }
}

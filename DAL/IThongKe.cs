using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
namespace DAL
{
    public interface IThongKe
    {
        List<thonhkesoluongtonkho> tksltk(DateTime nt, DateTime nd);
        thongkecongnodl tkcndl(DateTime nt, DateTime nd);
        List<thongketientrachonxb> tkcnnxb(DateTime nt, DateTime nd);
    }
}

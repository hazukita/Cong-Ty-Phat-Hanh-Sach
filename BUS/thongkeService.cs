using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
namespace BUS
{
    public static class thongkeService
    {
        static IThongKe repository;
        static thongkeService()
        {
            repository = new ThongKe();
        }
        public static thongkecongnodl tkcndl(DateTime nt, DateTime nd)
        {
            return repository.tkcndl(nt, nd);
        }
        public static List<thongketientrachonxb> tkcnnxb(DateTime nt, DateTime nd)
        {
            return repository.tkcnnxb(nt, nd);
        }
        public static List<thonhkesoluongtonkho> tksltk(DateTime nt, DateTime nd)
        {
            return repository.tksltk(nt, nd);
        }
    }
}

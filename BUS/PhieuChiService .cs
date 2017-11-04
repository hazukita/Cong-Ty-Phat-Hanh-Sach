using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
namespace BUS
{
    public static class PhieuChiService
    {
        static IPhieuchiRepostiory Repostiory=null;
        static PhieuChiService()
        {
            Repostiory = new PhieuchiRepository();
        }
        public static int insert(phieuchi pt)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var tongtien = db.ReceiptNotes.Find(pt.id_phieunhap).totalPrice;
                decimal tongthu = 0;
                var countphiethu = db.Payments.Where(x => x.ReceiptNoteID == pt.id_phieunhap).Count();
                if (countphiethu > 0)
                {
                    tongthu = db.Payments.Where(x => x.ReceiptNoteID == pt.id_phieunhap).Select(y => y.price).Sum() + pt.thanhtoan;
                }
                if (tongtien < tongthu)
                {
                    return 1;
                }
                else
                {
                    var rs= Repostiory.insert(pt);
                    if (rs)
                    {
                        return 2;
                    }
                    else
                    {
                        return 3;
                    }
                }
            }
           
        }
        public static List<phieuchi> GetAll(int id)
        {
            return Repostiory.GetAll(id);
        }
    }
}

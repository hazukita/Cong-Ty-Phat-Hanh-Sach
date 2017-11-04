using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
namespace BUS
{
    public static class PhieuThuService
    {
        static IPhieuthuRepostiory Repostiory=null;
        static PhieuThuService()
        {
            Repostiory = new PhieuthuRepository();
        }
        public static int insert(phieuthu pt)
        {
            using(CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var tongtien = db.DeliveryNotes.Find(pt.id_phieuxuat).totalPrice;

                var tongthu = db.Debts.Where(x => x.DeliveryNoteID == pt.id_phieuxuat).Select(y => y.thanhtoan).Sum()+ pt.thanhtoan;

                if(tongtien < tongthu)
                {
                    return 1;
                }
                else
                {
                    var rs = Repostiory.insert(pt);
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
        public static List<phieuthu> GetAll(int id)
        {
            return Repostiory.GetAll(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace DAL
{
    public class PhieuchiRepository : IPhieuchiRepostiory
    {
        public List<phieuchi> GetAll(int id)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var model = (from a in db.Payments
                             where a.ReceiptNoteID == id
                             select new phieuchi()
                             {
                                 id=a.PaymentID,
                                 nguoithu=a.creatorName,
                                 id_phieunhap=a.ReceiptNoteID,
                                 thanhtoan=a.price,
                                 ngaylap=a.dateCreated
                             }).OrderBy(x=>x.ngaylap).ToList();
                return model;
            }
        }
        public bool insert(phieuchi pt)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                try
                {
                    var entity = new Payments();
                    entity.ReceiptNoteID = pt.id_phieunhap;
                    entity.creatorName = pt.nguoithu;
                    entity.dateCreated = pt.ngaylap;
                    entity.price = pt.thanhtoan;
                    db.Payments.Add(entity);
                    db.SaveChanges();
                    return true;
                }catch(Exception ex)
                {
                    return false;
                }
            }
        }
    }
}

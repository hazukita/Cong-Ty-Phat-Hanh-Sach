using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace DAL
{
    public class PhieuthuRepository : IPhieuthuRepostiory
    {
        public List<phieuthu> GetAll(int id)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var model = (from a in db.Debts
                             where a.DeliveryNoteID == id
                             select new phieuthu()
                             {
                                 id=a.DebtID,
                                 nguoithu=a.creatorName,
                                 id_phieuxuat=a.DeliveryNoteID,
                                 thanhtoan=a.thanhtoan,
                                 ngaylap=a.dateCreated
                             }).OrderBy(x=>x.ngaylap).ToList();
                return model;
            }
        }
        public bool insert(phieuthu pt)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                try
                {
                    var entity = new Debts();
                    entity.DeliveryNoteID = pt.id_phieuxuat;
                    entity.creatorName = pt.nguoithu;
                    entity.dateCreated = pt.ngaylap;
                    entity.id_dl = pt.id_daily;
                    entity.thanhtoan = pt.thanhtoan;
                    db.Debts.Add(entity);
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

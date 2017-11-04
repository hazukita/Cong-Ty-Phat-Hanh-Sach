using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace DAL
{
    public class DaiyRepository : IDailyRepository
    {
        public void Delete(daily obj)
        {
            throw new NotImplementedException();
        }

        public List<daily> GetAllCate()
        {
           using(CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var model = (from a in db.Agencies
                             select new daily()
                             {
                                 id = a.AgencyID,
                                 name = a.agencyName,
                                 address=a.agencyAddress,
                                 mucno=a.maxdebt
                             }).ToList();
                return model;
            }
        }

        public daily GetCatById(int id)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var model = (from a in db.Agencies
                             where a.AgencyID==id
                             select new daily()
                             {
                                 id = a.AgencyID,
                                 name = a.agencyName,
                                 address = a.agencyAddress,
                                 mucno = a.maxdebt
                             }).FirstOrDefault();
                return model;
            }
        }

        public bool Insert(daily obj)
        {
            using(CTyPHSachEntities db = new CTyPHSachEntities())
            {
                try
                {
                    var d = new Agencies();
                    d.agencyName = obj.name;
                    d.agencyAddress = obj.address;
                    d.maxdebt = obj.mucno;
                    d.indebted = 0;
                    db.Agencies.Add(d);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
                
            }
        }       
        public bool Update(daily obj)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                try
                {
                    var d = db.Agencies.Find(obj.id);
                    d.agencyName = obj.name;
                    d.agencyAddress = obj.address;
                    d.maxdebt = obj.mucno;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
        public bool delete(daily obj)
        {
            throw new NotImplementedException();
        }

        bool IDailyRepository.Delete(daily obj)
        {
            throw new NotImplementedException();
        }
    }
}

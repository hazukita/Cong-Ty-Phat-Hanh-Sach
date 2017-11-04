using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace DAL
{
    public class NxbRepository : INxbRepository
    {
        public void Delete(nxb obj)
        {
            throw new NotImplementedException();
        }

        public List<nxb> GetAll()
        {
            using(CTyPHSachEntities db= new CTyPHSachEntities())
            {
                var model = (from a in db.Publishers
                             select new nxb()
                             {
                                 id = a.PublisherID,
                                 name = a.publisherName
                             }).ToList();
                return model;
            }
        }

        public nxb GetCatById(int id)
        {
            throw new NotImplementedException();
        }

        public nxb Insert(nxb obj)
        {
            throw new NotImplementedException();
        }

        public void Update(nxb obj)
        {
            throw new NotImplementedException();
        }
    }
}

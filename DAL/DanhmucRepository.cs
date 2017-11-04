using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace DAL
{
    public class DanhmucRepository : IDanhmuc
    {
        public void Delete(category obj)
        {
            throw new NotImplementedException();
        }

        public List<category> GetAllCate()
        {
           using(CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var model = (from a in db.Categories
                             select new category()
                             {
                                 id= a.CategoryID,
                                 name=a.CategoryName
                             }).ToList();
                return model;
            }

        }

        public category GetCatById(int id)
        {
            throw new NotImplementedException();
        }

        public category Insert(category obj)
        {
            throw new NotImplementedException();
        }

        public void Update(category obj)
        {
            throw new NotImplementedException();
        }
    }
}

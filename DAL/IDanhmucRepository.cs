using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
namespace DAL
{
    public interface IDanhmuc
    {
        List<category> GetAllCate();
        category GetCatById(int id);
        category Insert(category obj);
        void Update(category obj);
        void Delete(category obj);
    }
}

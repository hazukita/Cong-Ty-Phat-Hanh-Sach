using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace DAL
{
    public interface IPhieuxuatRepository
    {
        List<phieuxuat> GetAll(phieuxuatSearch s);
        phieuxuat GetCatById(int id);
        bool Insert(phieuxuat obj);
        bool Update(phieuxuat obj);
        bool Delete(phieuxuat obj);
    }
}

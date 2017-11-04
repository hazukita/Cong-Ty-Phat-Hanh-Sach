using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
namespace DAL
{
    public interface INxbRepository
    {
        List<nxb> GetAll();
        nxb GetCatById(int id);
        nxb Insert(nxb obj);
        void Update(nxb obj);
        void Delete(nxb obj);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
namespace DAL
{
    public interface IPhieuchiRepostiory
    {
        List<phieuchi> GetAll(int id);
        bool insert(phieuchi pt);
    }
}

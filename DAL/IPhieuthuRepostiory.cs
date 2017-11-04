using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
namespace DAL
{
    public interface IPhieuthuRepostiory
    {
        List<phieuthu> GetAll(int id);
        bool insert(phieuthu pt);
    }
}

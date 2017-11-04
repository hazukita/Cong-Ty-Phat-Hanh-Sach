using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
namespace DAL
{
    public interface IDailyRepository
    {
        List<daily> GetAllCate();
        daily GetCatById(int id);
        bool Insert(daily obj);
        bool Update(daily obj);
        bool Delete(daily obj);
    }
}

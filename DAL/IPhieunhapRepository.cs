using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
namespace DAL
{
    public interface IPhieunhapRepository
    {
        List<phieunhap> GetAll(phieunhapsearch s);
        phieunhap GetCatById(int id);
        bool Insert(phieunhap obj);
        bool Update(phieunhap obj);
        bool Delete(phieunhap obj);
    }
}

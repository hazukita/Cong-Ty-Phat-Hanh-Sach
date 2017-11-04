using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
namespace BUS
{
    public static class PhieunhapServeic
    {
        static IPhieunhapRepository repository;
        static PhieunhapServeic()
        {
            repository = new PhieunhapRepository();
        }
        public static List<phieunhap> GetAllBooks(phieunhapsearch s)
        {
            return repository.GetAll(s);
        }
        public static phieunhap GetBookById(int id)
        {
            return repository.GetCatById(id);
        }

        public static bool Insert(phieunhap obj)
        {
            return repository.Insert(obj);
        }
        public static bool Update(phieunhap obj)
        {
          return   repository.Update(obj);
        }
        public static bool Delete(phieunhap obj)
        {
           return  repository.Delete(obj);
        }
    }
}

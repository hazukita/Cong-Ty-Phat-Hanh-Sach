using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
namespace BUS
{
    static public class DanhmucService
    {
        static IDanhmuc repository;
        static DanhmucService()
        {
            repository = new DanhmucRepository();
        }
        public static List<category> GetAllBooks()
        {
            return repository.GetAllCate();
        }
        public static category GetBookById(int id)
        {
            return repository.GetCatById(id);
        }
        
        public static category Insert(category obj)
        {
            return repository.Insert(obj);
        }
        public static void Update(category obj)
        {
            repository.Update(obj);
        }
        public static void Delete(category obj)
        {
            repository.Delete(obj);
        }
    }
}

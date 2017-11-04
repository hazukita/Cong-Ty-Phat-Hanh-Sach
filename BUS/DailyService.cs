using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
namespace BUS
{
    public static class DailyService
    {
        static IDailyRepository repository;
        static DailyService()
        {
            repository = new DaiyRepository();
        }
        public static List<daily> GetAll()
        {
            return repository.GetAllCate();
        }
        public static daily GetBookById(int id)
        {
            return repository.GetCatById(id);
        }

        public static bool Insert(daily obj)
        {
            return repository.Insert(obj);
        }
        public static bool  Update(daily obj)
        {
           return  repository.Update(obj);
        }
        public static bool Delete(daily obj)
        {
           return repository.Delete(obj);
        }
    }
}

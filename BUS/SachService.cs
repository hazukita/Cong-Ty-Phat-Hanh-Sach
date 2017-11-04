using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
namespace BUS
{
    public static class SachService
    {
        static ISachRepository repository;
        static SachService()
        {
            repository = new SachRepository();
        }
        public static List<book> GetAll()
        {
            return repository.GetAll();
        }
        public static List<book> GetAllBooks(int page = 1)
        {
            return repository.GetAllBooks(page);
        }
        public static book GetBookById(int id)
        {
            return repository.GetBookById(id);
        }
        public static List<book> GetBookByobj(bookSearch bs , int page=1)
        {
            return repository.GetBookByobj(bs,page);
        }
        public static bool InsertBook(book obj)
        {
            return repository.InsertBook(obj);
        }
        public static bool UpdateBook(book obj)
        {
            return repository.UpdateBook(obj);
        }
        public static bool DeleteBook(int id)
        {
           return repository.DeleteBook(id);
        }
    }
}

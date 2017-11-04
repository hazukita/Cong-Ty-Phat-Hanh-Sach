using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
namespace DAL
{
    public interface ISachRepository
    {
        List<book> GetAllBooks(int page = 1);
        List<book> GetAll();
        book GetBookById(int id);
        List<book> GetBookByobj(bookSearch bs,int page = 1);
        bool InsertBook(book obj);
        bool UpdateBook(book obj);
        bool DeleteBook(int id);
    }
}

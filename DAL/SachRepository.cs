using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
namespace DAL
{
    public class SachRepository : ISachRepository
    {
        public bool DeleteBook(int id)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var obj = db.Books.Find(id);
                obj.status = 2;
                db.SaveChanges();
                return true;
            }
        }

        public List<book> GetAll()
        {

            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var book = (from a in db.Books
                            where a.status != 2
                            select new book()
                            {
                                ma = a.BookID,
                                ten = a.bookName,
                                gianhap = a.receiptPrice,
                                giaxuat = a.price,
                                id_nxb = a.PublisherID,
                                id_danhmuc = a.CategoryID,
                                sl = a.amount,
                                nhaxb = (from b in db.Publishers
                                         where b.PublisherID == a.PublisherID
                                         select new nxb()
                                         {
                                             id = b.PublisherID,
                                             name = b.publisherName
                                         }).FirstOrDefault(),
                                cat = (from c in db.Categories
                                       where c.CategoryID == a.CategoryID
                                       select new category()
                                       {
                                           id = c.CategoryID,
                                           name = c.CategoryName
                                       }).FirstOrDefault()
                            }).ToList();
                return book;
            }
        }

        public List<book> GetAllBooks(int page = 1)
        {
            int RecordsPerPage = 10;
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var book = (from a in db.Books
                            where a.status != 2
                            select new book()
                            {
                                ma = a.BookID,
                                ten = a.bookName,
                                gianhap = a.receiptPrice,
                                giaxuat = a.price,
                                id_nxb = a.PublisherID,
                                id_danhmuc = a.CategoryID,
                                sl = a.amount,
                                nhaxb = (from b in db.Publishers
                                         where b.PublisherID==a.PublisherID
                                         select new nxb()
                                         {
                                             id = b.PublisherID,
                                             name = b.publisherName
                                         }).FirstOrDefault(),
                                cat = (from c in db.Categories
                                       where c.CategoryID==a.CategoryID
                                       select new category()
                                       {
                                           id = c.CategoryID,
                                           name = c.CategoryName
                                       }).FirstOrDefault()
                            }).OrderBy(x=>x.ten).Skip((page - 1) * RecordsPerPage).Take(RecordsPerPage).ToList();
                return book;
            }
        }
        public List<book> GetBookByobj(bookSearch bs,int page = 1)
        {
            int RecordsPerPage = 10;
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var book = (from b in db.Books
                           where (bs.ten==null || b.bookName.Contains(bs.ten)) &&
                           b.status != 2
                           && (bs.mota == null || b.description.Contains(bs.mota)) &&
                          (bs.id_danhmuc == null || b.CategoryID== bs.id_danhmuc.Value)
                          && (bs.ma == null || b.BookID == bs.ma.Value)
                          && (bs.id_nxb == null || b.PublisherID==bs.id_nxb.Value) &&
                          (bs.gianhap == null || b.receiptPrice >= bs.gianhap.Value) &&
                          (bs.gianhapden == null || b.receiptPrice <= bs.gianhapden.Value) &&
                          (bs.giaxuat == null || b.price >= bs.giaxuat.Value) &&
                          (bs.giaxuatden == null || b.price <= bs.giaxuatden.Value)


                          select new book()
                           {
                               ma = b.BookID,
                               ten = b.bookName,
                               gianhap = b.receiptPrice,
                               giaxuat = b.price,
                                sl = b.amount,
                                id_nxb = b.PublisherID,
                               id_danhmuc = b.CategoryID,
                               nhaxb = (from c in db.Publishers
                                        where c.PublisherID==b.PublisherID
                                        select new nxb()
                                        {
                                            id = c.PublisherID,
                                            name = c.publisherName
                                        }).FirstOrDefault(),
                               cat = (from d in db.Categories
                                      where d.CategoryID==d.CategoryID
                                      select new category()
                                      {
                                          id = d.CategoryID,
                                          name = d.CategoryName
                                      }).FirstOrDefault()
                           }).OrderBy(x => x.ten).Skip((page - 1) * RecordsPerPage).Take(RecordsPerPage).ToList();
                return book;
            }

        }

        public book GetBookById(int id)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var model = (from a in db.Books
                             where a.BookID.Equals(id)
                             select new book()
                             {
                                 ma = a.BookID,
                                 ten = a.bookName,
                                 gianhap = a.receiptPrice,
                                 giaxuat = a.price,
                                 id_nxb = a.PublisherID,
                                 id_danhmuc = a.CategoryID,
                                 sl=a.amount,
                                 mota = a.description,
                                 img = a.img,
                                 nhaxb = (from b in db.Publishers
                                          where b.PublisherID==a.PublisherID
                                          select new nxb()
                                          {
                                              id = b.PublisherID,
                                              name = b.publisherName
                                          }).FirstOrDefault(),
                                 cat = (from c in db.Categories
                                        where c.CategoryID==a.CategoryID
                                        select new category()
                                        {
                                            id = c.CategoryID,
                                            name = c.CategoryName
                                        }).FirstOrDefault()
                             }).FirstOrDefault();
                return model;
            }
        }

        public bool InsertBook(book obj)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                try
                {
                    Books op = new Books();
                    op.bookName = obj.ten;
                    op.CategoryID = obj.id_danhmuc;
                    op.PublisherID = obj.id_nxb;
                    op.description = obj.mota;
                    op.price = obj.giaxuat;
                    op.receiptPrice = obj.gianhap;
                    op.author = obj.ten;
                    op.amount = 0;
                    op.img = obj.img;
                    db.Books.Add(op);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                
               
            }
        }
     
        public bool UpdateBook(book obj)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                try
                {
                    Books op = db.Books.Find(obj.ma);
                    op.bookName = obj.ten;
                    op.CategoryID = obj.id_danhmuc;
                    op.PublisherID = obj.id_nxb;
                    op.description = obj.mota;
                    op.price = obj.giaxuat;
                    op.receiptPrice = obj.gianhap;
                    op.author = obj.ten;
                    op.amount = 0;
                    op.img = obj.img;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}

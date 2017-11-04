using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;

namespace DAL
{
    public class PhieunhapRepository : IPhieunhapRepository
    {
        public bool Delete(phieunhap obj)
        {
            throw new NotImplementedException();
        }
        public List<phieunhap> GetAll(phieunhapsearch s)
        {
            using(CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var model = (from a in db.ReceiptNotes
                             where (s.nguoigiao==null || a.receiptName.Contains(s.nguoigiao)) &&
                             (s.id_nxb == null || a.PublisherID == s.id_nxb) &&
                             (s.id == null || a.ReceiptNoteID==s.id) &&
                             (s.nguoinhan == null || a.senderName.Contains(s.nguoinhan)) &&
                             (s.tientu == null || a.totalPrice >= s.tientu) &&
                             (s.tienden == null || a.totalPrice <= s.tienden) &&
                             (s.ngaytu==null ||a.receiptDateCreated>=s.ngaytu) &&
                              (s.ngayden == null || a.receiptDateCreated <=s.ngayden)
                             select new phieunhap()
                             {
                                 id=a.ReceiptNoteID,
                                 ngayxuat=a.receiptDateCreated,
                                 nguoigia =a.senderName,
                                 nguoitao=a.receiptName,
                                 id_nxb=a.PublisherID,
                                 giatri=a.totalPrice,
                                 phieuchi = (from c in db.Payments
                                             where c.ReceiptNoteID==a.ReceiptNoteID
                                             select new phieuchi()
                                             {
                                                 id=c.PaymentID,
                                                 id_phieunhap=c.ReceiptNoteID,
                                                 nguoithu=c.creatorName,
                                                 ngaylap=c.dateCreated,
                                                 thanhtoan=c.price
                                             }).ToList(),
                                 nxb=(from b in db.Publishers
                                      where a.PublisherID ==b.PublisherID
                                      select new nxb() {
                                          id=b.PublisherID,
                                          name=b.publisherName
                                      }).FirstOrDefault()
                             }).ToList();
                return model;
            }
        }

        public phieunhap GetCatById(int id)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var model = (from a in db.ReceiptNotes
                             where a.ReceiptNoteID == id
                             select new phieunhap()
                             {
                                 id = a.ReceiptNoteID,
                                 giatri = a.totalPrice,
                                 nguoitao = a.receiptName,
                                 id_nxb=a.PublisherID,
                                 nguoigia = a.senderName,
                                 ngayxuat = a.receiptDateCreated,
                                 phieuchi = (from c in db.Payments
                                             where c.ReceiptNoteID == a.ReceiptNoteID
                                             select new phieuchi()
                                             {
                                                 id = c.PaymentID,
                                                 id_phieunhap = c.ReceiptNoteID,
                                                 nguoithu = c.creatorName,
                                                 ngaylap = c.dateCreated,
                                                 thanhtoan = c.price
                                             }).ToList(),
                                 chitiet = (from b in db.ReceiptDetails
                                            where b.ReceiptNoteID == a.ReceiptNoteID
                                            select new Chitietphieunhap()
                                            {
                                                masach = b.BookID,
                                                mapn = b.ReceiptNoteID,
                                                sach = (from s in db.Books
                                                        where s.BookID == b.BookID
                                                        select new sach()
                                                        {
                                                            id=s.BookID,
                                                            name=s.bookName
                                                        }).FirstOrDefault(),
                                                sl = b.receiptAmount,
                                                gia = b.totalPrice
                                            }).ToList()
                             }).FirstOrDefault();
                return model;
            }
        }

        public bool Insert(phieunhap obj)
        {
            
                using (CTyPHSachEntities db = new CTyPHSachEntities())
                {
                try
                {
                    int id = db.ReceiptNotes.Max(x => x.ReceiptNoteID) + 10;
                    var ob = new ReceiptNotes();
                    ob.ReceiptNoteID = id;
                    ob.receiptName = obj.nguoigia;
                    ob.senderName = obj.nguoitao;
                    ob.totalPrice = obj.giatri;
                    ob.PublisherID = obj.id_nxb;
                    ob.subid = id;
                    ob.receiptDateCreated = obj.ngayxuat;
                    db.ReceiptNotes.Add(ob);

                    List<ReceiptDetails> rd = new List<ReceiptDetails>();
                    foreach (var item in obj.chitiet)
                    {
                        var ct = new ReceiptDetails();
                        var s = db.Books.Find(item.masach);
                        s.amount = s.amount + item.sl;
                        ct.BookID = item.masach;
                        ct.ReceiptNoteID = id;
                        ct.receiptAmount = item.sl;
                        ct.totalPrice = s.receiptPrice;
                        rd.Add(ct);
                    }
                    db.ReceiptDetails.AddRange(rd);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            
            
        }

        public bool Update(phieunhap obj)
        {
            throw new NotImplementedException();
        }
    }
}

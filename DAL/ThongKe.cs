using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
namespace DAL
{
    public class ThongKe : IThongKe
    {
        public thongkecongnodl tkcndl(DateTime nt, DateTime nd)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                thongkecongnodl tk = new thongkecongnodl();
                tk.ctg = (from a in db.DeliveryNotes
                             where (nt == null || a.deliverDateCreated >= nt.Date) &&
                             (nd == null || a.deliverDateCreated <= nd.Date)
                             select new chitietthongkecongnodl() {
                                 id = a.DeliveryNoteID,
                                 datecreate = a.deliverDateCreated,
                                 nguoigiao = a.deliverName,
                                 nguoinhan = a.receiverName,
                                 tongtien = a.totalPrice,
                                 dl = (from b in db.Agencies
                                       where b.AgencyID == a.AgencyID
                                       select new daily()
                                       {
                                           id = b.AgencyID,
                                           name = b.agencyName
                                       }).FirstOrDefault(),
                                 tientra = (from c in db.Debts
                                            where c.DeliveryNoteID == a.DeliveryNoteID
                                            select c.thanhtoan).Sum().HasValue? (from c in db.Debts
                                                                                 where c.DeliveryNoteID == a.DeliveryNoteID
                                                                                 select c.thanhtoan).Sum().Value:0,
                                 tienno = a.totalPrice-(db.Debts.Where(x=>x.DeliveryNoteID==a.DeliveryNoteID).Select(x=>x.thanhtoan).Sum().HasValue? db.Debts.Where(x => x.DeliveryNoteID == a.DeliveryNoteID).Select(x => x.thanhtoan).Sum().Value:0)
                             }).ToList();
                tk.tongcong = tk.ctg.Select(x => x.tongtien).Sum();
                tk.tongno = tk.ctg.Select(x => x.tienno).Sum().HasValue ? tk.ctg.Select(x => x.tienno).Sum().Value:0;
                tk.tongthu = tk.ctg.Select(x => x.tienno).Sum().Value;
                return tk;
            }
        }

        public List<thonhkesoluongtonkho> tksltk(DateTime nt, DateTime nd)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var lPhieuXuat = (from a in db.DeliveryDetails
                                 from b in db.DeliveryNotes
                                 where a.DeliveryNoteID == b.DeliveryNoteID &&
                                 (nd == null || b.deliverDateCreated <= nd.Date)
                                  group a by new { a.BookID } into g
                                  select new chitet {
                                    id = g.Key.BookID,
                                    sl = g.Sum(p=>p.amount)
                                  });
                var lPhieunhap = (from a in db.ReceiptNotes
                                  from b in db.ReceiptDetails
                                  where a.ReceiptNoteID == b.ReceiptNoteID &&
                                   (nd == null || a.receiptDateCreated <= nd.Date)
                                  group b by new { b.BookID } into g
                                  select new chitet
                                  {
                                      id = g.Key.BookID,
                                      sl = g.Sum(p => p.receiptAmount)
                                  });
                var lsach = (from a in db.Books
                             join b in lPhieuXuat on a.BookID equals b.id into j
                             from c in j.DefaultIfEmpty()
                             join d in lPhieunhap on a.BookID equals d.id into k
                             from e in k.DefaultIfEmpty()
                             select new thonhkesoluongtonkho()
                             {
                                 id = a.BookID,
                                 slht = a.amount,
                                 gia = a.price,
                                 name = a.bookName,
                                 gianhap = a.receiptPrice,
                                 nxb = (from l in db.Publishers
                                        where l.PublisherID == a.PublisherID
                                        select new nxb()
                                        {
                                            id = l.PublisherID,
                                            name = l.publisherName
                                        }).FirstOrDefault(),
                                 slx = c.sl.HasValue?c.sl.Value:0,
                                 sln = e.sl.HasValue ? e.sl.Value : 0,
                                 sltk =(e.sl.HasValue ? e.sl.Value : 0) - (c.sl.HasValue ? c.sl.Value : 0)
                             }).ToList();

                return lsach;
            }
        }

        public List<thongketientrachonxb> tkcnnxb(DateTime nt, DateTime nd)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var model = (from a in db.ReceiptNotes
                             where (nt == null || a.receiptDateCreated >= nt.Date) &&
                             (nd == null || a.receiptDateCreated <= nd.Date)
                             select new thongketientrachonxb()
                             {
                                 id = a.ReceiptNoteID,
                                 datecreate = a.receiptDateCreated,
                                 nguoigiao = a.receiptName,
                                 nguoinhan = a.senderName,
                                 tongtien = a.totalPrice,
                                 nxb = (from b in db.Publishers
                                        where b.PublisherID == a.PublisherID
                                        select new nxb()
                                        {
                                            id = b.PublisherID,
                                            name = b.publisherName
                                        }).FirstOrDefault(),
                                 tientra = (from c in db.Payments
                                            where c.ReceiptNoteID == a.ReceiptNoteID
                                            select c.price).Sum(),
                              tienno = a.totalPrice - (db.Payments.Where(x => x.ReceiptNoteID == a.ReceiptNoteID).Select(x => x.price).Sum()),
                          }).ToList();
               
                return model;
            }
        }

    }
}
  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
namespace DAL
{
    public class PhieuxuatRepository : IPhieuxuatRepository
    {
        public bool Delete(phieuxuat obj)
        {
            throw new NotImplementedException();
        }

        public List<phieuxuat> GetAll(phieuxuatSearch s)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var model = (from a in db.DeliveryNotes
                             where (s.nguoigiao == null || a.receiverName.Contains(s.nguoigiao)) &&
                             (s.id == null || a.DeliveryNoteID == s.id) &&
                             (s.id_dl == null || a.AgencyID == s.id_dl) &&
                             (s.nguoinhan == null || a.deliverName.Contains(s.nguoinhan)) &&
                             (s.tientu == null || a.totalPrice >= s.tientu) &&
                             (s.tienden == null || a.totalPrice <= s.tienden) &&
                             (s.ngaytu == null || a.deliverDateCreated >= s.ngaytu) &&
                              (s.ngayden == null || a.deliverDateCreated <= s.ngayden)
                             select new phieuxuat()
                             {
                                 id = a.DeliveryNoteID,
                                 ngayxuat = a.deliverDateCreated,
                                 nguoigia = a.deliverName,
                                 nguoitao = a.receiverName,
                                 hanthanhtoan = a.endeliverdate,
                                 id_dl = a.AgencyID,
                                 giatri = a.totalPrice,
                                 dl = (from b in db.Agencies
                                       where a.AgencyID == b.AgencyID
                                       select new daily()
                                       {
                                           id = b.AgencyID,
                                           name = b.agencyName
                                       }).FirstOrDefault()
                             }).ToList();
                return model;
            }
        }

        public phieuxuat GetCatById(int id)
        {
            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                var model = (from a in db.DeliveryNotes
                             where a.DeliveryNoteID == id
                             select new phieuxuat()
                             {
                                 id = a.DeliveryNoteID,
                                 ngayxuat = a.deliverDateCreated,
                                 nguoigia = a.deliverName,
                                 nguoitao = a.receiverName,
                                 id_dl = a.AgencyID,
                                 hanthanhtoan = a.endeliverdate,
                                 giatri = a.totalPrice,
                                 phieuthu = (from c in db.Debts
                                             where a.DeliveryNoteID==c.DeliveryNoteID
                                             select new phieuthu() {
                                                 id=c.DebtID,
                                                 ngaylap=c.dateCreated,
                                                 id_phieuxuat=c.DeliveryNoteID,
                                                 nguoithu=c.creatorName,
                                                 thanhtoan=c.thanhtoan
                                             }).ToList(),
                                 chitiet = (from b in db.DeliveryDetails
                                            where b.DeliveryNoteID == a.DeliveryNoteID
                                            select new Chitietphieuxuat()
                                            {
                                                masach = b.BookID,
                                                mapn = b.DeliveryNoteID,
                                                sl = b.amount,
                                                sach = (from s in db.Books
                                                        where b.BookID == s.BookID
                                                        select new sach()
                                                        {
                                                            id =s.BookID,
                                                            name =s.bookName
                                                        }).FirstOrDefault(),
                                                gia = b.price
                                            }).ToList()
                             }).FirstOrDefault();
                return model;
            }
        }

        public bool Insert(phieuxuat obj)
        {

            using (CTyPHSachEntities db = new CTyPHSachEntities())
            {
                try
                {
                    int id = db.DeliveryNotes.Max(x => x.DeliveryNoteID) + 10;
                    var ob = new DeliveryNotes();
                    ob.DeliveryNoteID = id;
                    ob.deliverName = obj.nguoigia;
                    ob.receiverName = obj.nguoitao;
                    ob.totalPrice = obj.giatri;
                    ob.AgencyID = obj.id_dl;
                    ob.endeliverdate = obj.hanthanhtoan;
                    ob.deliverDateCreated = obj.ngayxuat;
                    db.DeliveryNotes.Add(ob);
                    
                    List<DeliveryDetails> rd = new List<DeliveryDetails>();
                    foreach (var item in obj.chitiet)
                    {
                        var ct = new DeliveryDetails();
                        var s = db.Books.Find(item.masach);
                        s.amount = s.amount - item.sl;
                        ct.BookID = item.masach;
                        ct.DeliveryNoteID = id;
                        ct.amount = item.sl;
                        ct.price = s.receiptPrice;
                        rd.Add(ct);
                    }

                    db.DeliveryDetails.AddRange(rd);

                    if (obj.thanhtoan > 0) {
                        var tt = new Debts();
                        tt.DeliveryNoteID = id;
                        tt.dateCreated = obj.ngayxuat;
                        tt.thanhtoan = obj.thanhtoan;
                        tt.id_dl = obj.id_dl;
                        tt.creatorName = obj.nguoitao;
                        db.Debts.Add(tt);
                    }
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }


        }


        public bool Update(phieuxuat obj)
        {
            throw new NotImplementedException();
        }
    }
}

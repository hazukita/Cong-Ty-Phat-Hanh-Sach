using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;
namespace BUS
{
    public static class PhieuxuatService
    {
        static IPhieuxuatRepository repository;
        static PhieuxuatService()
        {
            repository = new PhieuxuatRepository();
        }
        public static List<phieuxuat> GetAllBooks(phieuxuatSearch s)
        {
            return repository.GetAll(s);
        }
        public static phieuxuat GetBookById(int id)
        {
            return repository.GetCatById(id);
        }

        public static int Insert(phieuxuat obj)
        {
            List<int> idsach = new List<int>();
            //kiem tra so luong
            foreach (var item in obj.chitiet)
            {
                var b = SachService.GetBookById(item.masach);
                if (b.sl < item.sl)
                {
                    idsach.Add(item.masach);
                }
            }
            if (idsach.Count() > 0)
            {
                return 1;
            }
            //kiem tra ngay no

            //kiem tra muc no
            decimal? mucno = DailyService.GetBookById(obj.id_dl).mucno;
            decimal tienno = obj.giatri - (obj.thanhtoan.HasValue ? obj.thanhtoan.Value : 0);
            if (tienno > mucno)
            {
                return 2;
            }

            var res = repository.Insert(obj);
            if (res)
            {
                return 3;
            }
            else
            {
                return 4;
            }
           
        }
        public static bool Update(phieuxuat obj)
        {
            return repository.Update(obj);
        }
        public static bool Delete(phieuxuat obj)
        {
            return repository.Delete(obj);
        }
    }
}

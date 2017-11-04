using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DAL;

namespace BUS
{
    public static class NxbServeic
    {
        static INxbRepository repository;
        static NxbServeic()
        {
            repository = new NxbRepository();
        }
        public static List<nxb> GetAll()
        {
            return repository.GetAll();
        }
    }
}

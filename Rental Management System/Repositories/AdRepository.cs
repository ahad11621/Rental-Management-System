using Rental_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rental_Management_System.Repositories
{
    public class AdRepository : Repository<Ad>
    {
        //Ahad
        public IEnumerable<Ad> GetAllAd()
        {
            return this.GetAll().Where(x => x.Status == 1).ToList();

        }

        //Mim
        public IEnumerable<Ad> GetAcceptedAd()
        {
            return this.GetAll().Where(x => x.Status == 1).ToList();

        }

        public IEnumerable<Ad> GetbyAd(int id)
        {
            return this.GetAll().Where(x => x.Status == 1 && x.AdId == id).ToList();

        }

        public IEnumerable<Ad> GetRequest()
        {
            return this.GetAll().Where(x => x.Status == 0).ToList();

        }
        public Ad GetRequestbyId(int id)
        {
            return this.GetAll().Where(x => x.Status == 0 && x.AdId == id).FirstOrDefault();

        }
    }
}
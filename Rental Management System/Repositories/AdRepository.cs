using Rental_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rental_Management_System.Repositories
{
    public class AdRepository : Repository<Ad>
    {
        public IEnumerable<Ad> GetAllAd()
        {
            return this.GetAll().Where(x => x.Status == 1).ToList();

        }
    }
}
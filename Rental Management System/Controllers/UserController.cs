using Rental_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rental_Management_System.Controllers
{
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        AdRepository adRepo = new AdRepository();
        UserRepository userRepo = new UserRepository();

        [Route("{id}/ads")]
        public IHttpActionResult GetAdsbyUserId([FromUri] int id)
        {
            return Ok(adRepo.GetAdsByUserId(id));
        }
    }
}

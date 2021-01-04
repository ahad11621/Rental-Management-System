using Rental_Management_System.Models;
using Rental_Management_System.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rental_Management_System.Controllers
{
    [RoutePrefix("api/profile")]
    public class ProfileController : ApiController
    {
        UserRepository userRepo = new UserRepository();

        [Route("{id}")]  // view profile
        public IHttpActionResult GetbyId(int id)
        {
            return Ok(userRepo.Get(id));
        }

        [Route("{id}")]  // update profile
        public IHttpActionResult Put([FromUri] int id, User user)
        {
            var adr = userRepo.Get(id);
            adr.Name = user.Name;
            adr.UserName = user.UserName;
            adr.Password = user.Password;
            adr.Email = user.Email;
            adr.Phone = user.Phone;
            userRepo.Update(adr);
            return Ok(adr);
        }

        [Route("{id}")]  // delete profile
        public IHttpActionResult Delete([FromUri] int id)
        {

            userRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}

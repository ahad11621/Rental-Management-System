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
    public class LoginController : ApiController
    {
        UserRepository userRepo = new UserRepository();
        [Route("api/login")]
        public IHttpActionResult Post(User user)
        {
            var log = userRepo.CheckLogin(user.UserName, user.Password);
            if (log != null)
            {

                return Ok(log);
            }
            else
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

        [Route("api/register")]
        public IHttpActionResult PostRegister(User user)
        {
            user.Status = 1;
            user.Type = 1;
            userRepo.Insert(user);
            return Created("api/profile/id", new { id = user.UserId });
        }
    }
}

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
    public class AdminController : ApiController
    {
        AdRepository adRepo = new AdRepository();
        UserRepository userRepo = new UserRepository();
        SpecificationRepository specRepo = new SpecificationRepository();
        AddressRepository addressRepo = new AddressRepository();

        [Route("api/allAds")] // view all accepted ad
        public IHttpActionResult Get()
        {
            return Ok(adRepo.GetAcceptedAd().ToList());
        }

        [Route("api/allAds/{id}")]  // view all accepted ad by id
        public IHttpActionResult GetbyIdAds(int id)
        {
            return Ok(adRepo.GetbyAd(id).ToList());
        }

        [Route("api/requestAd")]        // view requested ad
        public IHttpActionResult GetRequestAd()
        {
            var view = adRepo.GetRequest();
            if (view == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(adRepo.GetRequest());
        }

        [Route("api/requestAd/{id}")] //view requested ad by id
        public IHttpActionResult GetbyRequestAd(int id)
        {

            return Ok(adRepo.GetRequestbyId(id));
        }

        [Route("api/requestAd/{id}")]  //accepting ad
        public IHttpActionResult Put(int id, Ad ad)
        {
            var adr = adRepo.GetRequestbyId(id);
            adr.Status = 1;
            adRepo.Update(adr);
            return Ok(adr);
        }

        [Route("api/requestAd/{id}")]  //deleting ad
        public IHttpActionResult Delete(int id)
        {
            var adr = adRepo.Get(id);
            adRepo.Delete(id);
            specRepo.Delete(adr.SpecId);
            addressRepo.Delete(adr.AddressId);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("api/allUsers")]  // view all users
        public IHttpActionResult GetUsers()
        {
            return Ok(userRepo.GetAllUsers());
        }
        [Route("api/allUsers/{id}")] // ban user
        public IHttpActionResult Putusers(int id, User user)
        {
            var adr = userRepo.Get(id);
            adr.Status = 0;
            userRepo.Update(adr);
            return Ok(adr);
        }

        [Route("api/userSearch")]  // search user by name
        public IHttpActionResult GetSearchUsers(string find)
        {
            return Ok(userRepo.GetSearch(find));
        }
    }
}

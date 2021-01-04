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
    [RoutePrefix("api/ads")]
    public class AdController : BaseController
    {
        AddressRepository addressRepo = new AddressRepository();
        AdRepository adRepo = new AdRepository();
        SpecificationRepository specificationRepo = new SpecificationRepository();
        UserRepository userRepo = new UserRepository();

        [Route("")]
        public IHttpActionResult Get() //Get all Ad
        {
            return Ok(adRepo.GetAllAd().ToList());
        }

        //Get one ad by id
        [Route("{id}", Name = "GetAdById")]
        public IHttpActionResult Get(int id)
        {
            BaseUrl = Request.RequestUri.Scheme + "://" + Request.RequestUri.Host + ":" + Request.RequestUri.Port;
            var ad = adRepo.Get(id);
            if (ad == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            ad.Links = ad.CreateLinks(BaseUrl);
            return Ok(ad);
        }

        //Post a Ad
        [Route("")]
        public IHttpActionResult Post(Ad ad)
        {
            LastAddressId = addressRepo.GetAll().Max(x => x.AddressId);

            var thisAddress = addressRepo.GetAll().Where(x => x.AddressId == LastAddressId).FirstOrDefault();
            UserIdFromAddress = thisAddress.UserId;

            LastSpecificationId = specificationRepo.GetAll().Max(x => x.SpecId);

            ad.UserId = UserIdFromAddress;
            ad.SpecId = LastSpecificationId;
            ad.AddressId = LastAddressId;
            ad.Status = 0;
            ad.Availability = 1;

            adRepo.Insert(ad);
            string uri = Url.Link("GetAdById", new { id = ad.AdId });
            return Created(uri, ad);
        }

        //Update Ad's Specifaction
        [Route("{id}/specifications/{sid}")]
        public IHttpActionResult PutSpecification([FromUri] int sid, [FromBody] Specification specification)
        {
            specification.SpecId = sid;

            specificationRepo.Update(specification);
            return Ok(specification);
        }

        //Update Ad's Address
        [Route("{id}/addresses/{aid}")]
        public IHttpActionResult PutAddress([FromUri] int aid, [FromBody] Address address)
        {
            address.AddressId = aid;

            addressRepo.Update(address);
            return Ok(address);
        }

        //Delete Ad
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var Ad = adRepo.Get(id);
            adRepo.Delete(id);
            specificationRepo.Delete(Ad.SpecId);
            addressRepo.Delete(Ad.AddressId);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}

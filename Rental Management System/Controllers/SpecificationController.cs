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
    [RoutePrefix("api/specifications")]
    public class SpecificationController : BaseController
    {
        AddressRepository addressRepo = new AddressRepository();
        SpecificationRepository specificationRipo = new SpecificationRepository();

        //Show all Specification
        [Route("")]
        public IHttpActionResult Get() //Get all Ad
        {
            return Ok(specificationRipo.GetAll());
        }

        //Show Specification by Id
        [Route("{id}", Name = "GetSpecificationById")]
        public IHttpActionResult Get(int id)
        {
            //BaseUrl = Request.RequestUri.Scheme + "://" + Request.RequestUri.Host + ":" + Request.RequestUri.Port;
            var specification = specificationRipo.Get(id);
            if (specification == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            //add.Links = category.CreateLinks(BaseUrl, "GetOne");
            return Ok(specification);
        }

        //Insert a Specification
        [Route("")]
        public IHttpActionResult Post(Specification specification)
        {
            //Get Last Address id
            LastAddressId = addressRepo.GetAll().Max(x => x.AddressId);
            specification.AddressId = LastAddressId;

            specificationRipo.Insert(specification);
            string uri = Url.Link("GetSpecificationById", new { id = specification.SpecId });
            return Created(uri, specification);
        }
    }
}

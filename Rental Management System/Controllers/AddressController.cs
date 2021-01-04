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
    [RoutePrefix("api/addresses")]
    public class AddressController : BaseController
    {
        AddressRepository addressRepo = new AddressRepository();

        //Show all Address
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(addressRepo.GetAll());
        }

        //Show ad by Id
        [Route("{id}", Name = "GetAddressById")]
        public IHttpActionResult Get(int id)
        {
            BaseUrl = Request.RequestUri.Scheme + "://" + Request.RequestUri.Host + ":" + Request.RequestUri.Port;
            var address = addressRepo.Get(id);
            if (address == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            address.Links = address.CreateLinks(BaseUrl);
            return Ok(address);
        }

        //Insert a Address
        [Route("")]
        public IHttpActionResult Post(Address address)
        {
            addressRepo.Insert(address);
            string uri = Url.Link("GetAddressById", new { id = address.AddressId });
            return Created(uri, address);
        }

    }
}

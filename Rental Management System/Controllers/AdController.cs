﻿using Rental_Management_System.Models;
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
        AdRepository adRipo = new AdRepository();
        SpecificationRepository specificationRipo = new SpecificationRepository();
        UserRepository userRipo = new UserRepository();

        [Route("")]
        public IHttpActionResult Get() //Get all Ad
        {
            return Ok(adRipo.GetAllAd().ToList());
        }


        [Route("{id}", Name = "GetAdById")]
        public IHttpActionResult Get(int id)//Get one ad by id
        {
            //BaseUrl = Request.RequestUri.Scheme + "://" + Request.RequestUri.Host + ":" + Request.RequestUri.Port;
            var ad = adRipo.Get(id);
            if (ad == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            //category.Links = category.CreateLinks(BaseUrl, "GetOne");
            return Ok(ad);
        }

        //Post a Ad
        [Route("")]
        public IHttpActionResult Post(Ad ad)
        {
            LastAddressId = addressRepo.GetAll().Max(x => x.AddressId);

            var thisAddress = addressRepo.GetAll().Where(x => x.AddressId == LastAddressId).FirstOrDefault();
            UserIdFromAddress = thisAddress.UserId;

            LastSpecificationId = specificationRipo.GetAll().Max(x => x.SpecId);

            ad.UserId = UserIdFromAddress;
            ad.SpecId = LastSpecificationId;
            ad.AddressId = LastAddressId;
            ad.Status = 0;
            ad.Availability = 1;

            adRipo.Insert(ad);
            string uri = Url.Link("GetAdById", new { id = ad.AdId });
            return Created(uri, ad);
        }

        //[Route("{id}")]
        //public IHttpActionResult Put([FromUri] int id, [FromBody] Category category)
        //{
        //    category.CategoryId = id;
        //    categoryRipository.Update(category);
        //    return Ok(category);
        //}
        //[Route("{id}")]
        //public IHttpActionResult Delete(int id)
        //{
        //    categoryRipository.Delete(id);
        //    return StatusCode(HttpStatusCode.NoContent);
        //}
    }
}

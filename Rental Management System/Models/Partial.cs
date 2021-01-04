using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rental_Management_System.Models
{
    public partial class Ad
    {
        public List<Link> Links = new List<Link>();

        public Ad Another()
        {
            return new Ad()
            {
                Links = this.Links,
                AdId = this.AdId
            };
        }
        public List<Link> CreateLinks(string baseurl)
        {
            var links = new List<Link>();
            links.Add(new Link()
            {
                Url = baseurl + "/api/ads/",
                Method = "GET",
                Relation = "Get All Ads"
            });
            links.Add(new Link()
            {
                Url = baseurl + "/api/ads/" + this.AdId,
                Method = "GET",
                Relation = "Get Ad by Id"
            });
            links.Add(new Link()
            {
                Url = baseurl + "/api/ads/",
                Method = "POST",
                Relation = "Create new Ad"
            });
            links.Add(new Link()
            {
                Url = baseurl + "/api/ads/" + this.AdId,
                Method = "PUT",
                Relation = "Edit this Ad"
            });
            links.Add(new Link()
            {
                Url = baseurl + "/api/ads/" + this.AdId,
                Method = "DELETE",
                Relation = "Delete this Ad"
            });
            return links;
        }
    }

    public partial class Address
    {
        public List<Link> Links = new List<Link>();

        public Address Another()
        {
            return new Address()
            {
                Links = this.Links,
                AddressId = this.AddressId
            };
        }
        public List<Link> CreateLinks(string baseurl)
        {
            var links = new List<Link>();
            links.Add(new Link()
            {
                Url = baseurl + "/api/addresses/",
                Method = "GET",
                Relation = "Get All address"
            });
            links.Add(new Link()
            {
                Url = baseurl + "/api/addresses/" + this.AddressId,
                Method = "GET",
                Relation = "Get address by Id"
            });
            links.Add(new Link()
            {
                Url = baseurl + "/api/addresses/",
                Method = "POST",
                Relation = "Create new address"
            });
            links.Add(new Link()
            {
                Url = baseurl + "/api/addresses/" + this.AddressId,
                Method = "PUT",
                Relation = "Edit this address"
            });
            links.Add(new Link()
            {
                Url = baseurl + "/api/addresses/" + this.AddressId,
                Method = "DELETE",
                Relation = "Delete this address"
            });
            return links;
        }
    }

    public partial class Specification
    {
        public List<Link> Links = new List<Link>();

        public Specification Another()
        {
            return new Specification()
            {
                Links = this.Links,
                SpecId = this.SpecId
            };
        }
        public List<Link> CreateLinks(string baseurl)
        {
            var links = new List<Link>();
            links.Add(new Link()
            {
                Url = baseurl + "/api/specifications/",
                Method = "GET",
                Relation = "Get All specification"
            });
            links.Add(new Link()
            {
                Url = baseurl + "/api/specifications/" + this.SpecId,
                Method = "GET",
                Relation = "Get specification by Id"
            });
            links.Add(new Link()
            {
                Url = baseurl + "/api/specifications/",
                Method = "POST",
                Relation = "Create new specification"
            });
            links.Add(new Link()
            {
                Url = baseurl + "/api/specifications/" + this.SpecId,
                Method = "PUT",
                Relation = "Edit this specification"
            });
            links.Add(new Link()
            {
                Url = baseurl + "/api/specifications/" + this.AddressId,
                Method = "DELETE",
                Relation = "Delete this specification"
            });
            return links;
        }
    }
}
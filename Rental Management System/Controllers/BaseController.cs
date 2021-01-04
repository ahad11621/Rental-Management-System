using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Rental_Management_System.Controllers
{
    public class BaseController : ApiController
    {
        public string BaseUrl;
        public int LastAddressId;
        public int LastSpecificationId;
        public int UserIdFromAddress;
    }
}

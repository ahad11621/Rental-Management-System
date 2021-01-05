using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace Rental_Management_System.Attributes
{
    public class UserAuthenticationAttribute: AuthorizationFilterAttribute
    {
        public int userType;
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                if (userType == 1)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userType.ToString()), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
        public void getUserType(int t)
        {
            userType = t;
        }
    }
}
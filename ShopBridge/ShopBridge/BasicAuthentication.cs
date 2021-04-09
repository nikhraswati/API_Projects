using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ShopBridge
{
    public class BasicAuthentication: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                string username;
                string password;
                string token = actionContext.Request.Headers.Authorization.Parameter;
                string DecodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                var Credential = DecodedToken.Split(':');
                username = Credential[0];
                password = Credential[1];
                if(username.ToLower()=="thinkbridge" && password=="Thinkbridge@123")
                {
                    
                }
                else
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);

            }
        }
    }
}
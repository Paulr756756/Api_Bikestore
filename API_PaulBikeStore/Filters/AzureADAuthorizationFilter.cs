using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;

namespace API_PaulBikeStore.Filters
{
    /// <summary>
    /// Custom Authorization attricute class
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AzureADAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// This method will be called when we apply custom attribute on any method/controller
        /// </summary>
        /// <param name="context">authorization filter context</param>
        public AzureADAuthorizationFilter()
        { 
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var result = 0;
            var token= context.HttpContext.Request.Headers.Authorization;
            if (AuthenticationHeaderValue.TryParse(token, out var headerValue))
            {
                // we have a valid AuthenticationHeaderValue that has the following details:
                var scheme = headerValue.Scheme;
                var parameter = headerValue.Parameter;
                var handler = new JwtSecurityTokenHandler();
                var accessToken = handler.ReadJwtToken(parameter);
                var claims = accessToken.Claims.ToList();
                if (claims.Where(c => c.Type == "email").FirstOrDefault()!.Value==null)
                {
                    result--;
                    return;
                }
                if (claims.Where(c => c.Type == "iss").FirstOrDefault()!.Value != "https://sts.windows.net/c30073c0-06de-4827-ac7b-21ed11e2ff0f/")
                {
                }
                if (claims.Where(c => c.Type == "aud").FirstOrDefault()!.Value != "https://graph.microsoft.com")
                {
                }
                var iatLinuxDate = claims?.FirstOrDefault(x => x.Type == "iat")!.Value!;
                var issuedTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(iatLinuxDate)).DateTime;
                if (issuedTime.AddMinutes(Convert.ToDouble("6000")) < DateTime.UtcNow)
                {
                    result--;
                }
                var scopes = claims!.Where(c => c.Type == "scp").FirstOrDefault()!.Value.Split(" ");
                // here we are going to extract the claims and verify what all are the items which are present inside the claims section
                    
                }
            if (result==0)
            {
                context.ModelState.AddModelError("UnAuthorized", "You are not Authorized to view this application");
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new UnauthorizedObjectResult(context.ModelState);
                context.HttpContext.Response.Headers["MessageDetails"] = "You are not allowed to view this Application";
                context.HttpContext.Response.Headers["MessageType"] = "UnAuthorized";
                throw new UnauthorizedAccessException();
            }
                
        }
    }
}


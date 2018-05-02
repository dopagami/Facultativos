using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace FacultativosWebApi.Jwt.Filters
{
    public class JwtAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public string Realm { get; set; }
        public bool AllowMultiple => false;

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;

            try
            {                
                var authorization = request.Headers.Authorization;

                if (authorization == null || authorization.Scheme != "Bearer")
                    return;

                if (string.IsNullOrEmpty(authorization.Parameter))
                {
                    context.ErrorResult = new AuthenticationFailureResult("Missing Jwt Token", request);
                    return;
                }

                var token = authorization.Parameter;
                var principal = await AuthenticateJwtToken(token);

                context.Principal = principal;
            }
            catch (Exception ex)
            {
                context.ErrorResult = new AuthenticationFailureResult(ex.Message.ToString(), request);
            }
        }

        private static bool ValidateToken(string token, out string username, out ClaimsIdentity identity)
        {
            try
            {
                username = null;

                var simplePrinciple = JwtManager.GetPrincipal(token);

                if (simplePrinciple == null)
                    throw new Exception(JwtManager.ErrorMessages.IDX00000);

                identity = JwtManager.CreateIdentity(simplePrinciple);

                if (identity == null)
                    throw new Exception(JwtManager.ErrorMessages.IDX00000);

                if (!identity.IsAuthenticated)
                    throw new Exception(JwtManager.ErrorMessages.IDX00000);

                var usernameClaim = identity.FindFirst(ClaimTypes.Name);
                username = usernameClaim?.Value;

                if (string.IsNullOrEmpty(username))
                    throw new Exception(JwtManager.ErrorMessages.IDX00000);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            try
            {
                string username;

                ClaimsIdentity identityK;

                if (ValidateToken(token, out username, out identityK))
                {
                    // based on username to get more information from database in order to build local identity
                    var claims = new List<Claim>();

                    foreach (var claim in identityK.Claims)
                    {
                        switch (claim.Type)
                        {
                            case "http://schemas.microsoft.com/ws/2008/06/identity/claims/role":
                                claims.Add(new Claim(ClaimTypes.Role, claim.Value));
                                break;
                            case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name":
                                claims.Add(new Claim(ClaimTypes.GivenName, claim.Value));
                                break;
                            case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname":
                                claims.Add(new Claim(ClaimTypes.Surname, claim.Value));
                                break;
                            case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress":
                                claims.Add(new Claim(ClaimTypes.Email, claim.Value));
                                break;
                        }
                    }

                    var identity = new ClaimsIdentity(claims, "Jwt");
                    IPrincipal user = new ClaimsPrincipal(identity);

                    return Task.FromResult(user);
                }

                return Task.FromResult<IPrincipal>(null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            Challenge(context);
            return Task.FromResult(0);
        }

        private void Challenge(HttpAuthenticationChallengeContext context)
        {
            string parameter = null;

            if (!string.IsNullOrEmpty(Realm))
                parameter = "realm=\"" + Realm + "\"";

            context.ChallengeWith("Bearer", parameter);
        }
    }
}

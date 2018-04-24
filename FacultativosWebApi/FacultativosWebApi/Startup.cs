using Microsoft.Owin;
using Owin;

using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security;
using Owin.Security.Keycloak;

[assembly: OwinStartup(typeof(FacultativosWebApi.Startup))]

namespace FacultativosWebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);

            // Name of the persistent authentication middleware for lookup
            const string persistentAuthType = "KeycloakOwinAuthenticationSample_cookie_auth";

            // --- Cookie Authentication Middleware - Persists user sessions between requests
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = persistentAuthType
            });
            app.SetDefaultSignInAsAuthenticationType(persistentAuthType); // Cookie is primary session store

            // --- Keycloak Authentication Middleware - Connects to central Keycloak database
            app.UseKeycloakAuthentication(new KeycloakAuthenticationOptions
            {
                // App-Specific Settings
                ClientId = "demo-app", // *Required*
                ClientSecret = "5b834700-2f8a-4622-bb51-9eb80a5f52dd", // If using public authentication, delete this line
                VirtualDirectory = "", // Set this if you use a virtual directory when deploying to IIS

                // Instance-Specific Settings
                Realm = "PruebaRealm", // Don't change this unless told to do so
                KeycloakUrl = "http://mk22788p:8081/auth", // Enter your Keycloak URL here

                // Template-Specific Settings
                SignInAsAuthenticationType = persistentAuthType, // Sets the above cookie with the Keycloak data
                AuthenticationType = "KeycloakOwinAuthenticationSample_keycloak_auth", // Unique identifier for the auth middleware
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using FacultativosWebApi.Jwt.Filters;

namespace FacultativosWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Habilitar CORS
            var corsAttribute = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttribute);

            //Quitar formateadores sobrantes
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.Add(new XmlMediaTypeFormatter());

            // Configuración y servicios de Web API
            // Configure Web API para usar solo la autenticación de token de portador.
            //config.SuppressDefaultHostAuthentication();
            //config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API configuration and services
            config.Filters.Add(new JwtAuthenticationAttribute());

            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

using System.Net.Http.Headers;
using System.Web.Http;

namespace API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{distance}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Convert output into JSON format
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            //Enable tracing
            config.EnableSystemDiagnosticsTracing();

        }
    }
}

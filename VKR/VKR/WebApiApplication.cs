﻿using System.Web.Http;

namespace VKR
{
    public class WebApiApplication
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
        
            // Web API routes
        
            config.EnableCors();
        
            config.MapHttpAttributeRoutes();
        
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
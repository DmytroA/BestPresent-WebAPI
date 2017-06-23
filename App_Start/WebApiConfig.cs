using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BestPresent.WebAPI.Models;

namespace BestPresent.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            ModelMapper.Init();
            // Конфигурация и службы веб-API
            config.EnableCors();

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

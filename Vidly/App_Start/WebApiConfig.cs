﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
 using Newtonsoft.Json;
 using Newtonsoft.Json.Serialization;

namespace Vidly
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var settings=config.Formatters.JsonFormatter.SerializerSettings;
            settings.Formatting=Formatting.Indented;
            settings.ContractResolver=new CamelCasePropertyNamesContractResolver();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

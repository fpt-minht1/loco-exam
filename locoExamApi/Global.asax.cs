using System;
using System.Diagnostics;
using System.Web.Http;
using locoExamApi;

namespace locoExamApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
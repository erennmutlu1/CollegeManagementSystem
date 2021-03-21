using Autofac;
using AutoMapper;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CollegeManagementSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory(new LanguageConfig()));
            ModelBinders.Binders.Add(typeof(decimal), new DecimalConfig());
            Mapper.Initialize(c => c.AddProfile<MapperConfig>());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InverseConfig.RegisterDependencies();
        }
    }
}
using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace CollegeManagementSystem
{
    public class LanguageConfig : IControllerActivator
    {
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            //Get the {language} parameter in the RouteData
            string language = requestContext.RouteData.Values["language"] == null ?
                "en-US" : requestContext.RouteData.Values["language"].ToString();

            //Get the culture info of the language code
            CultureInfo culture = CultureInfo.GetCultureInfo(language);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}
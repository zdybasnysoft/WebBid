using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebBid.Binders;
using WebBid.Models.ViewModels;

namespace WebBid
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
       //     ModelBinders.Binders.Add(typeof(MatchPreparationViewModel), new MatchParametersBinder());

        }
    }
}

using System.Web.Mvc;

namespace SistRE.Areas.Mantenimientos
{
    public class MantenimientosAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Mantenimientos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Mantenimientos_default",
                "Mantenimientos/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
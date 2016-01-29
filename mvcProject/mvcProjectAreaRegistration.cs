using System.Web.Mvc;

namespace BP.Areas.mvcProject
{
    public class mvcProjectAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "mvcProject";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "mvcProject_default",
                "mvcProject/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
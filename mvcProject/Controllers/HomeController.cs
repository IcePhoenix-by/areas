using Beltelecom.Domain.Repository;
using BP.Areas.mvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BP.Areas.mvcProject.Controllers
{
    public class HomeController : Controller
    {
        UserRepository a = new UserRepository(new Context.bdConnectionString());
        // GET: mvcProject/Home
        public ActionResult Index()
        {
            return View(a.get(UserClasses.User.id_user));
        }

        [HttpPost]
        public ActionResult Index(SUser item)
        {
            if (ModelState.IsValid)
            {
                var changeItem = a.get(UserClasses.User.id_user);
                changeItem.SUserSur = item.SUserSur;
                changeItem.SUserFirst = item.SUserFirst;
                changeItem.SUserPatr = item.SUserPatr;
                changeItem.SUserPost = item.SUserPost;
                changeItem.SUserPhone = item.SUserPhone;
                changeItem.SUserEmail = item.SUserEmail;
                a.Update(changeItem);
                a.savechange();
                
                return Redirect(Request.ApplicationPath+"/index.aspx");
            }
            else
            {
                return View(item); 
            }
        }
    }
}
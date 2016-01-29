using BP.Areas.mvcProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Specialized;

namespace BP.Areas.mvcProject.Controllers
{
    public class SLineGrafController : Controller
    {
       
        public ActionResult SLineGraf()
        {
            //UserClasses.UsersDB.
            string userRoles = Session["roles"].ToString();
            int branchId = UserClasses.User.id_Branch;
            int branchRuesId = UserClasses.User.id_BranchRues;

            var model = new List<SLineGraf>();
            string connString = UserClasses.functions.getConnection();

            using (var connection = new SqlConnection(connString))
            {
                //List<TypeGroupKey> formTypes;
                ////List<BranchesRelation> relations;
                //var branshInfos = new SortedList<int, BranchInfo>();
                connection.Open();

                //if (userRoles.IndexOf("Administrator"))
                string slgquery = @"SELECT     SLineGraf.SLineGrafId, SLineGraf.SLineGrafName, SLineGraf.SLineGrafUpdate, SLineGraf.SUserId, 
                      SUser.SUserSur + ' ' + SUser.SUserFirst + ' ' + SUser.SUserPatr AS UserName
                        FROM         SLineGraf LEFT OUTER JOIN
                      SUser ON SLineGraf.SUserId = SUser.SUserId";
                var slgCommand = new SqlCommand(slgquery, connection);

                using (SqlDataReader slgReader = slgCommand.ExecuteReader())
                {
                    foreach (var rec in slgReader.Cast<IDataRecord>())
                    {
                        SLineGraf slg=new SLineGraf();
                        slg.SLineGrafId=(int)rec["SLineGrafId"];
                        slg.SLineGrafName=rec["SLineGrafName"].ToString();
                        slg.SLineGrafUpdate = (DateTime)rec["SLineGrafUpdate"];
                        slg.UserName=rec["UserName"].ToString();
                        model.Add(slg);
                    }
                }

                
            }
            return View(model);
        }
    }
}
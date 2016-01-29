using BP.Areas.mvcProject.Models.Nsi;
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
using BP.UserClasses.BranchesTree;

namespace BP.Areas.mvcProject.Controllers
{
    // Нормативно-справочная информация
    public class NsiController : Controller
    {
        class BranchInfo : BranchRelation<BranchTreeItemModel>
        {
            public string Name { get; set; }
            public string Code { get; set; }
        }

        // GET: mvcProject/Nsi
        [HttpGet]
        public ActionResult Manage()
        {
            //UserClasses.UsersDB.
            string userRoles = Session["roles"].ToString();
            int branchId = UserClasses.User.id_Branch;
            int branchRuesId = UserClasses.User.id_BranchRues;

            var model = new FormCatalog();
            string connString = UserClasses.functions.getConnection();

            using (var connection = new SqlConnection(connString))
            {
                List<TypeGroupKey> formTypes;
                //List<BranchesRelation> relations;
                var branshInfos = new SortedList<int, BranchInfo>();
                connection.Open();

                //if (userRoles.IndexOf("Administrator"))
                string branchesRelationsQueryStr = "SELECT SBranchId, SBranchIdd, SBranchKod, SBranchName FROM SBranch";
                var branchesRelationsCommand = new SqlCommand(branchesRelationsQueryStr, connection);

                using (SqlDataReader branchesRelationsReader = branchesRelationsCommand.ExecuteReader())
                {
                    foreach(var rec in branchesRelationsReader.Cast<IDataRecord>())
                    {
                        branshInfos.Add(
                                (int)rec["SBranchId"],
                                new BranchInfo
                                {
                                    ParentId = rec["SBranchIdd"] as int?,
                                    Code = rec["SBranchKod"] as string,
                                    Name = rec["SBranchName"] as string
                                });
                    }
                }

                //model.BranchTree = BranchTree.Build(
                //        1,
                //        branshInfos,
                //        info => new BranchTreeItemModel
                //                {
                //                    Id = info.Key,
                //                    Name = info.Value.Name,
                //                    Code = info.Value.Code
                //                });

                string formTypesQueryStr = "SELECT STypeFormId, STypeFormName, STypeFormNote FROM STypeForm";
                var formTypesCommand = new SqlCommand(formTypesQueryStr, connection);
                using (SqlDataReader formTypesReader = formTypesCommand.ExecuteReader())
                {
                    formTypes = formTypesReader.Cast<IDataRecord>()
                            .Select(rec => new TypeGroupKey
                            {
                                TypeId = (int)rec["STypeFormId"],
                                TypeName = rec["STypeFormName"] as string
                            })
                            .ToList();
                }

                string formsQueryStr =
                        "SELECT MForm.SGroupId, SGroup.SGroupName, MForm.MFormKod, MForm.MFormName, " +
                        "SFormPeriod.SFormPeriodName, MForm.MFormDateStart, " +
                        "MForm.MFormDateEnd, MForm.MFormPublish, MForm.MFormId, MForm.STypeFormId " +
                        "FROM MForm " +
                        "INNER JOIN SFormPeriod ON MForm.SFormPeriodId = SFormPeriod.SFormPeriodId " +
                        "INNER JOIN SGroup ON MForm.SGroupId = SGroup.SGroupId " +
                        "ORDER BY MForm.SGroupId";

                var getFormsCmd = new SqlCommand(formsQueryStr, connection);
                using (SqlDataReader formsReader = getFormsCmd.ExecuteReader())
                {
                    model.GroupedRecords = formsReader.Cast<IDataRecord>()
                            .Select(rec => new FormCatalogRecord()
                            {
                                Id = (int)rec["MFormId"],
                                Code = rec["MFormKod"] as string,
                                Name = rec["MFormName"] as string,
                                DateStarts = rec["MFormDateStart"] as DateTime?,
                                DateEnds = rec["MFormDateEnd"] as DateTime?,
                                PublishDate = rec["MFormPublish"] as DateTime?,
                                GroupId = rec["SGroupId"] as int?,
                                GroupName = rec["SGroupName"] as string,
                                Period = rec["SFormPeriodName"] as string,
                                TypeId = (int)rec["STypeFormId"]
                            })
                            .GroupBy(record => record.TypeId,
                                    (typeId, records) => new Group
                                    {
                                        Key = formTypes.First(group => group.TypeId == typeId),
                                        Records = records
                                    })
                            .ToList(); 
                }

                var getTimeCmd = new SqlCommand("SELECT CURRENT_TIMESTAMP", connection);
                var time = (DateTime)getTimeCmd.ExecuteScalar();
                //ViewBag.Time = time;
                ViewData["Time"] = time;
            }
            return View(model);
        }

        [HttpGet]
        //public JsonResult FormBranches(int id)
        //public string FormBranches(int id)
        public ContentResult FormBranches(int id)
        {
            string connString = UserClasses.functions.getConnection();
            List<Branch> branches;
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                string branchesQueryStr = "SELECT TFormBranch.SBranchId, SBranch.SBranchKod, TFormBranch.TFormDateStart, " +
                                            "TFormBranch.TFormDateEnd, SBranch.SBranchName " +
                                            "FROM TFormBranch " +
                                            "INNER JOIN SBranch ON TFormBranch.SBranchId = SBranch.SBranchId " +
                                            "WHERE MFormId = @FormId ";
                var getBranchesCmd = new SqlCommand(branchesQueryStr, connection);
                getBranchesCmd.Parameters.AddWithValue("FormId", id);
                using (SqlDataReader branchesReader = getBranchesCmd.ExecuteReader())
                {
                    branches = branchesReader.Cast<IDataRecord>()
                            .Select(rec => new Branch
                            {
                                Id = (int)rec["SBranchId"],
                                Name = rec["SBranchName"] as string,
                                Code = rec["SBranchKod"] as string,
                                DateStarts = rec["TFormDateStart"] as DateTime?,
                                DateEnds = rec["TFormDateEnd"] as DateTime?
                            })
                            .ToList();
                }
            }

            //Newtonsoft.Json.JsonConvert.SerializeObject(branches);
            //return Json(branches, JsonRequestBehavior.AllowGet);
            //return Newtonsoft.Json.JsonConvert.SerializeObject(branches, new Newtonsoft.Json.Converters.IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy"}); 
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(branches, new Newtonsoft.Json.Converters.IsoDateTimeConverter() { DateTimeFormat = "dd.MM.yyyy" }), "application/json");
        }
    }
}
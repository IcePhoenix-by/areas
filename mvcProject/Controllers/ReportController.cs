using BP.UserClasses.Tree;
using System;
using System.Web.Mvc;
using Newtonsoft.Json;
using BP.Areas.mvcProject.Repository;
using BP.Areas.mvcProject.Context;
using System.Linq;
using System.Collections.Generic;
using BP.Areas.mvcProject.Models.Report;
using System.Web.Script.Serialization;

namespace BP.Areas.mvcProject.Controllers
{
    public class ReportController : Controller
    {
        static bdConnectionString dbconnection = new bdConnectionString();
        TreeRepository treeRepository = new TreeRepository(dbconnection);
        STypeFormRepository STypeFormRepository = new STypeFormRepository(dbconnection);
        MFormRepository MFormRepository = new MFormRepository(dbconnection);
        TFormBranchRepository TFormBranchRepository = new TFormBranchRepository(dbconnection);
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult Index2()
        {
            return View();

        }
        public string getTabs(string id)
        {
                var MForm = MFormRepository.getAll().ToList();
                var Tform = TFormBranchRepository.getAll().Where(a => a.SBranchId == Convert.ToInt16(id)).ToList();
                var myforms = from Mforms in MForm
                              join Tforms in Tform on Mforms.MFormId equals Tforms.MFormId
                              select new
                              {
                                  Mforms
                              };
                var formlist = myforms.ToList();
                var tabswithdate = new List<MForm>();
                var alltabs = STypeFormRepository.getAll().ToList();

                for (int i = 0; i < alltabs.Count(); i++)
                {
                    for (int j = 0; j < formlist.Count(); j++)
                    {
                        if (alltabs[i].StypeFormId == formlist[j].Mforms.STypeFormId)
                        {
                            tabswithdate.Add(formlist[j].Mforms);
                            alltabs[i].items = new List<MForm>(tabswithdate);
                        }


                    }
                    tabswithdate.Clear();
                }
                var jsonSerialiser = new JavaScriptSerializer();
                var result = JsonConvert.SerializeObject(alltabs, Formatting.None);
                return result;
            
        }

        public string GetTree()
        {
            var allBranch = treeRepository.getAll().ToList();
            var topBranch = treeRepository.get(1);
            topBranch.items.ToList();
            var middleBranch = new List<Sbranch>();
            var bottomBranch = new List<Sbranch>();
            for (int i = 0; i < allBranch.Count(); i++)
            {
                if (allBranch[i].SBranchIdd == 1)
                {
                    middleBranch.Add(allBranch[i]);
                }
            }
            var botBranch = new List<Sbranch>();
            for (int i = 0; i < middleBranch.Count(); i++)
            {
                for (int j = 0; j < allBranch.Count(); j++)
                {
                    if (middleBranch[i].SBranchId == allBranch[j].SBranchIdd)
                    {
                        bottomBranch.Add(allBranch[j]);
                        middleBranch[i].items = new List<Sbranch>(bottomBranch);
                    }
                }
                bottomBranch.Clear();
            }
            topBranch.items = middleBranch;
            var jsonSerialiser = new JavaScriptSerializer();
            var result = JsonConvert.SerializeObject(topBranch, Formatting.None);
            return result;
        }

    }
}
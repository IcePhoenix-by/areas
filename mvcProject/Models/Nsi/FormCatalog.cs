using BP.UserClasses.BranchesTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP.Areas.mvcProject.Models.Nsi
{
    public class FormCatalog
    {
        //public BranchTreeNode<BranchTreeItemModel> BranchTree { get; set; }   // пока не актуально
        public IEnumerable<Group> GroupedRecords { get; set; }
    }
}
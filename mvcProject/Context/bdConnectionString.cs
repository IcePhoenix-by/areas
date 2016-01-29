using BP.Areas.mvcProject.Models;
using BP.Areas.mvcProject.Models.Report;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BP.Areas.mvcProject.Context
{
    public class bdConnectionString : DbContext
    {
       public bdConnectionString()
        {
            Database.SetInitializer<bdConnectionString>(null);
        }
        DbSet<SUser> SUser { get; set; }
        DbSet<Sbranch> SBranch { get; set; }
        DbSet<STypeForm> STypeForm { get; set; }
        DbSet<MForm> MForm { get;set; }
        DbSet<TFormBranch> TFormBranch { get; set; }
    }
}
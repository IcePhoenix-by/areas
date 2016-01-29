using BP.Areas.mvcProject.Abstract;
using BP.Areas.mvcProject.Models.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BP.Areas.mvcProject.Models;
using BP.Areas.mvcProject.Context;

namespace BP.Areas.mvcProject.Repository
{
    public class ReportRepository : BaseRepository<Report>, IReportRepository
    {

        public ReportRepository(bdConnectionString context) : base(context) { }
    }
}
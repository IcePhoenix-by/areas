using BP.Areas.mvcProject.Abstract;
using BP.Areas.mvcProject.Context;
using BP.Areas.mvcProject.Models.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP.Areas.mvcProject.Repository
{
    public class TreeRepository:BaseRepository<Sbranch>,ITreeRepository
    {
        public TreeRepository(bdConnectionString context) : base(context)
        {

        }

       

    }
}
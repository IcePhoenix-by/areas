﻿using BP.Areas.mvcProject.Context;
using BP.Areas.mvcProject.Models.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP.Areas.mvcProject.Repository
{
    public class MFormRepository:BaseRepository<MForm>

    {
        public MFormRepository(bdConnectionString connection) : base(connection)
        {

        }
    }
}
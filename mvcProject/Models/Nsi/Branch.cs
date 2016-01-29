using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP.Areas.mvcProject.Models.Nsi
{
    public class Branch
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? DateStarts { get; set; }
        public DateTime? DateEnds { get; set; }
    }
}
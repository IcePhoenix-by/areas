using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP.Areas.mvcProject.Models.Nsi
{
    public class FormCatalogRecord
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }       //почему nullable?
        public string GroupName { get; set; }
        public int TypeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Period { get; set; }
        public DateTime? DateStarts { get; set; }
        public DateTime? DateEnds { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
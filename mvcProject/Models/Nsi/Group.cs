using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP.Areas.mvcProject.Models.Nsi
{
    public struct TypeGroupKey
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }

    public class Group
    {
        public TypeGroupKey Key { get; set; }
        public IEnumerable<FormCatalogRecord> Records { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BP.Areas.mvcProject.Models
{
    public class SLineGraf
    {
        public int SLineGrafId { get; set; }
        public string SLineGrafName { get; set; }
        public System.DateTime SLineGrafUpdate { get; set; }
        public int SUserId { get; set; }
        public string UserName { get; set; }
    }
    
}
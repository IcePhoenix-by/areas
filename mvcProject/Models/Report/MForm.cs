using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BP.Areas.mvcProject.Models.Report
{
    [Table("MForm")]
    public class MForm
    {   [Key]
        public int MFormId { get; set; }
        public int? MFormIdd { get; set; }
        public string MFormKod { get; set; }
        public string MFormName { get; set; }
        public DateTime? MFormDateStart { get; set; }
        public DateTime? MFormDateEnd { get; set; }
        public int SFormPeriodId { get; set; }
        public int STypeFormId { get; set; }
        public DateTime MFormUpdate { get; set; }
        public int SUserId { get; set; }
        public DateTime? MFormPublish { get; set; }
        public int? SGroupId { get; set; }
    }
}
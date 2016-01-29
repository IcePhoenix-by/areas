using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BP.Areas.mvcProject.Models.Report
{
    [Table("TFormBranch")]
    public class TFormBranch
    {   [Key]
        public int TFormBranchId { get; set; }
        public int MFormId { get; set; }
        public int SBranchId { get; set; }
        public DateTime TFormDateStart { get; set; }
        public DateTime? TFormDateEnd { get; set; }
        public DateTime TFormUdate { get; set; }
        public int SUserId { get; set; }
    }
}
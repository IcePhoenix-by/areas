using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BP.Areas.mvcProject.Models.Report
{
    [Table("Sbranch")]
    public class Sbranch
    {
        [Key]
        public int SBranchId { get; set; }
        public int? SBranchIdd { get; set; }
        public string SBranchName { get; set; }
        public string SBranchKod { get; set; }
        public int SBranchStr { get; set; }
        public DateTime SBranchUpdate { get; set; }
        public int SUserId { get; set; }
        public IEnumerable<Sbranch> items { get; set; }
        Sbranch()
        {
            items = new List<Sbranch>();
        }
    }
}
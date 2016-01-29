using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BP.Areas.mvcProject.Models.Report
{
    [Table("STypeForm")]
    public class STypeForm
    {
        [Key]
        public int StypeFormId { get; set; }
        public string STypeFormName { get; set; }
        public string STypeFormNote { get; set; }
        public int? STypeFormNum { get; set; }
        public IEnumerable<MForm> items { get; set; }
        STypeForm()
        {
            items = new List<MForm>();
        }
    }
}
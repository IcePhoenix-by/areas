using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BP.Areas.mvcProject.Models
{
    [Table("SUser")]
      public class SUser
    {
        public int SUserId { get; set; }
        public int SBranchId { get; set; }
        public string SUserLogin { get; set; }
        public string SUserPass { get; set; }
        [RegularExpression(@"^[а-яА-Я][а-яА-Я\\s]+$", ErrorMessage = "Некорректная Фамилия")]
        [Required(ErrorMessage = "поле \"Фамилия\" должно быть заполнено")]
        public string SUserSur { get; set; }
        [RegularExpression(@"^[а-яА-Я][а-яА-Я\\s]+$", ErrorMessage = "Некорректное Имя")]
        [Required(ErrorMessage = "поле \"Имя\" должно быть заполнено")]
        public string SUserFirst { get; set; }
        [RegularExpression(@"^[а-яА-Я][а-яА-Я\\s]+$", ErrorMessage = "Некорректное Отчество")]
        [Required(ErrorMessage = "Поле \"Отчество\" должно быть заполнено")]
        public string SUserPatr { get; set; }

        [Required(ErrorMessage = "Поле \"Телефон\" должно быть заполнено")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Некорректный телефон")]
        [StringLength(10, MinimumLength =10, ErrorMessage = "Длина строки должна быть 10 символов")]
        public string SUserPhone { get; set; }
        [Required(ErrorMessage = "Поле \"Email\" должно быть заполнено")]
        [EmailAddress(ErrorMessage = "Некорректный Email адрес")]
        public string SUserEmail { get; set; }
        public bool SUserBlocked { get; set; }
        public DateTime? SUserDateUpdate { get; set; }
        public DateTime? SUserDateBlocked { get; set; }
        public string SUserPost { get; set; }
        public int SUserAccess { get; set; }
    }
}
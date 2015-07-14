using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SLTest.Models.Interface;
using System.Web.Mvc;
using System.ComponentModel;

namespace SLTest.Models
{
    [MetadataType(typeof(WaitersValidation))]
    public partial class Waiters:IBase
    {
        [Bind(Exclude = "ID")]
        public class WaitersValidation
        {
            [ScaffoldColumn(false)]
            public Int32 ID { get; set; }

            [DisplayName("логин")]
            [Required(ErrorMessage = "Это обязательное поле")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [StringLength(25)]
            public string login { get; set; }
            [DisplayName("Имя")]
            [Required(ErrorMessage = "Это обязательное поле")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [StringLength(70)]
            public string name { get; set; }
        }
        public bool CanBeDeleted()
        {
            return true;
        }
    }
}
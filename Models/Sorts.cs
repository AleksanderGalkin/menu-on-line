using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;
using SLTest.Models.Interface;

namespace SLTest.Models
{
    [MetadataType(typeof(SortsValidation))]
    public partial class Sorts : IBase
    {


        [Bind(Exclude = "ID")]
        public class SortsValidation
        {
            [ScaffoldColumn(false)]
            public Int64 ID { get; set; }

            [DisplayName("Вид")]
            [Required(ErrorMessage = "Это обязательное поле")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [StringLength(50)]
            public string Sort { get; set; }
        }
        public bool CanBeDeleted()
        {
            return true;
        }
    }
}
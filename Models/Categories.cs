using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLTest.Models.Interface;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace SLTest.Models
{
    [MetadataType(typeof(CategoriesValidation))]
    public partial class Categories : IBase
    {


        [Bind(Exclude = "ID")]
        public class CategoriesValidation
        {
            [ScaffoldColumn(false)]
            public Int64 ID { get; set; }

            [DisplayName("Категория")]
            [Required(ErrorMessage = "Это обязательное поле")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [StringLength(50)]
            public string Category { get; set; }

            [DisplayName("Порядок сортировки")]
            [Required(ErrorMessage = "Это обязательное поле")]
            public Int32 Arrange { get; set; }
        }
        public bool CanBeDeleted()
        {
            return true;
        }
    }
}
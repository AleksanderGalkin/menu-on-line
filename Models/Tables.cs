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
    [MetadataType(typeof(TablesValidation))]
    public partial class Tables:IBase
    {
        [Bind(Exclude = "ID")]
        public class TablesValidation
        {
            [ScaffoldColumn(false)]
            public Int32 ID { get; set; }
            [DisplayName("номер столика")]
            public Int32 numTable { get; set; }
            [DisplayName("комментарий")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [StringLength(50)]
            public string comment { get; set; }
            [DisplayName("ответственный")]
            public Int32 waiterID { get; set; }
        }
        public bool CanBeDeleted()
        {
            return true;
        }
    }
}
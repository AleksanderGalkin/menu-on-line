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
    [MetadataType(typeof(OptionsValidation))]
    public partial class Options:IBase 
    {

        
        

        public bool CanBeDeleted()
        {
            return true;
        }

        public string StringForSelectList
        {
            
            get {
                String blank1="",blank2="";
                String blank = "\u00A0"; 
                int lenBlank1=25 - OptionName.Length;
                int lenBlank2=10 - Price.ToString().Length;

                for(int i=0;i<lenBlank1;i++)
                    blank1 = blank1 + blank;
                for(int i=0;i<lenBlank2 ;i++)
                    blank2 = blank2 + blank;

                if (OptID > 0)
                    return OptionName + ", " + string.Format(@"{0:#0.00р\.}", Price);
                else
                    return "";
            }
        }
        [Bind(Exclude = "OptID")]
        public class OptionsValidation
        {
            [ScaffoldColumn(false)]
            public Int64 OptID { get; set; }

            [DisplayName("Относится к блюду")]
            [Required(ErrorMessage = "Это обязательное поле")]
            public Int64 RecID { get; set; }


            [DisplayName("Дополнительный ингредиент")]
            [Required(ErrorMessage="Это обязательное поле")]
            [DisplayFormat(ConvertEmptyStringToNull=false)]
            [StringLength(50)]
            public string OptionName { get; set; }

            [DisplayName("Цена")]
            [Required(ErrorMessage = "Это обязательное поле")]
            [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode=true)]
            [Range(0.0,1000.0,ErrorMessage="Цена от 0.00 до 1000.00")]
            public decimal Price { get; set; }


        }
    }
}
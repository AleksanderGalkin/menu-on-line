using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SLTest.Service;
using SLTest.Service.Factory;
using System.ComponentModel.DataAnnotations;

namespace SLTest.Models
{
    public partial class itCart
    {

        private RecipeEntityService rs;
        private OptionsEntityService os;

            //public virtual shipTo ShipTo { get; set; }
        public itCart()
        {
            drink = 0; opt = null;
            rs = (RecipeEntityService)RecipeServiceFactory.Create();
            os = (OptionsEntityService)OptionsServiceFactory.Create();
        }
        public itCart(int d, int? o)
        {
            drink = d; opt = o;
            rs = (RecipeEntityService)RecipeServiceFactory.Create();
            os = (OptionsEntityService)OptionsServiceFactory.Create();
        }

            public string drinkName()
            {
                return rs.Get((int)drink).RecName;
            }
            public string optName()
            {
                if (opt != null)
                    return os.Get((int)opt).OptionName;
                else
                    return "";
            }
            public decimal drinkPrice()
            {
                return rs.Get((int)drink).Price;
            }
            public decimal optPrice()
            {
                if (opt != null)
                    return os.Get((int)opt).Price;
                else
                    return  0;
            }
            public decimal totalCost()
            {
                return drinkPrice() + optPrice();
            }
            public class itCartComparer : IEqualityComparer<itCart>
            {

                public bool Equals(itCart x, itCart y)
                {
                    return x.drink == y.drink && x.opt == y.opt;
                }
                public int GetHashCode(itCart x)
                { return (int)(x.drink ^ (x.opt==null?0:x.opt)); }
            }
    }



        [MetadataType(typeof(shipToValidation))]
           public partial class shipTo// оформление заказа
    {
            private OrderDashBoardsStagesEntityService s =
                new OrderDashBoardsStagesEntityService();

            public OrderStages getOState
            {
                get 
                {
                    return s.GetOrderState((int)this.ID);
                }
            }
            public int setOState (string Descr,string user)
            {
                
                     return s.SetOrderState((int)this.ID,Descr,user);
                
            }
            public OrderStages getPState
            {
                get
                {
                    return s.GetPayState((int)this.ID);
                }
            }
            public int setPState(string Descr, string user)
            {
                
                    return s.SetPayState((int)this.ID, Descr,  user);
            }    
            public  string PSystem { get; set; }
            public Boolean flPaid {
                get
                {
                  if (getPState!=null)
                    if (getPState.Descr.Contains("Оплачено"))
                        return true;
                  return false;
                }
            }
            public DateTime? dtPaid
            {
                get
                {
                    if (!flPaid)
                        return null;
                    else
                        return s.GetPayDateTime((int)this.ID);
                }
            }
             [Bind(Exclude = "ID")]
            public class shipToValidation
            {
                
                public Int64 ID { get; set; }
                [Display(Name="Номер столика",Prompt = "Посмотрте на табличке", Description = "Номер столика за которым сидите")]
                [Required(ErrorMessage="Надо заполнить, а не то заказ уйдёт на другой столик")]
                [Range(1, 12, ErrorMessage = "Надо правильно заполнить, а не то заказ уйдёт на другой столик")]
                public int? tableNum { get; set; }
                public DateTime OrderDateTime { get; set; }
                [Display(Name="Комментарий")]
                [UIHint("MultilineText")]
                [DisplayFormat(ConvertEmptyStringToNull = false)]
                [StringLength(50)]
                public string comment { get; set; }
                [Display(Name = "Способ оплаты")]
                public int formOfP { get; set; }
               // public Dictionary<itCart, int> Cart;
                [Display(Name = "Счёт сразу")]
                public bool flImmediateBill{ get; set; }
  
            }
            public shipTo()
            {
                formOfP = 1;
                flImmediateBill = false;
                OrderDateTime = DateTime.Now;
            }
            public  List<string> getListPSystems()
            {
                string[] t = { "Visa", "MasterCard", "Pro100", "UnionCard" };
                return t.ToList();
            }



    }


        [MetadataType(typeof(shipToValidation))]
        public partial class shipTo2:shipTo, IValidatableObject // оформление заказа
        {

           // public override string PSystem { get; set; }
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                coffeeEntities db = new coffeeEntities();
                List<ValidationResult> error = new List<ValidationResult>();
                string formOfPDescr = (from i in db.formOfP
                                       where i.ID == formOfP
                                       select i.Descr).FirstOrDefault();
                if (string.IsNullOrEmpty(formOfPDescr))
                    error.Add(new ValidationResult("В справочнике Форма платежа не найден вид 'Банковская карта'"));
                if (formOfPDescr.Trim() == "Банковская карта" && string.IsNullOrEmpty(PSystem))
                    error.Add(new ValidationResult("Выберите тип Вашей карты пожалуйста"));
                //throw new NotImplementedException();
                return error;
            }
        }


}
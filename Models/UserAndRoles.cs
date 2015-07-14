using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SLTest.Models.Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SLTest.Models
{
    [MetadataType(typeof(UserAndRoles))]
    [Bind(Exclude = "ID")]
    public class UserAndRoles:IBase
    {
        public string ID { get; set; }
        [DisplayName("Наименование роли")]
        [StringLength(50)]
        public string roleName { get; set; }
        [DisplayName("Список пользователей")]
        public string[] users { get; set; }

        public bool CanBeDeleted()
        {
            return true;
        }
    }
}
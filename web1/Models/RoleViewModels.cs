using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web1.Models
{
    public class RoleCreateViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }
    }

    public class AddRoleViewModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }
    }
}
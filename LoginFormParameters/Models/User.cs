using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoginFormParameters.Models
{
    public class User
    {
        [Required(ErrorMessage = "enter username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "enter password")]
        public string Password { get; set; }
    }
}
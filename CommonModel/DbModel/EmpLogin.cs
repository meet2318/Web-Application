using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonModel.DbModel
{
        public class EmpLogin
        {
        public string Email { get; set; }

        public string Password { get; set; }

        
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        }
}

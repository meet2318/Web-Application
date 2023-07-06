using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CommonModel.ViewModel
{
        public  class EmployeeDetailsViewModel
        {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Designation { get; set; }
        
        public int DesignationId { get; set; }

        public string ProfilePicture { get; set; }
        
        public int Salary { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date_Of_Birth { get; set; }
        
        public string Email { get; set; }
        
        public string Address { get; set; }

        [NotMapped]
        public HttpPostedFileBase ProfilePictures { get; set; }
    }
}

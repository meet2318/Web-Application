using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace CommonModel.DbModel
{
    public class EmployeeDetails
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the designation.</summary>
        /// <value>The designation.</value>
        public string Designation { get; set; }

        /// <summary>Gets or sets the designation identifier.</summary>
        /// <value>The designation identifier.</value>
        public int DesignationId { get; set; }

        /// <summary>Gets or sets the profile picture.</summary>
        /// <value>The profile picture.</value>
        public string  ProfilePicture { get; set; }

        /// <summary>Gets or sets the salary.</summary>
        /// <value>The salary.</value>
        public int Salary { get; set; }

        /// <summary>Gets or sets the date of birth.</summary>
        /// <value>The date of birth.</value>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date_Of_Birth { get; set; }
        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>Gets or sets the address.</summary>
        /// <value>The address.</value>
        public string Address { get; set; }


    }
}

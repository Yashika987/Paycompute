using Paycompute.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Paycompute.Models
{
    public class EmployeeCreateViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Employee Number is required"),
        RegularExpression(@"^[A-Z]{3,3}[0-9]{3}")]
        public string EmployeeNo { get; set; }
        [Required(ErrorMessage = "First Name is required"), StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$"), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required"), StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$"), Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string FullName {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string Gender { get; set; }
        [Display(Name = "Photo")]
        public string ImageUrl { get; set; }
        [DataType(DataType.Date), Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        [DataType(DataType.Date), Display(Name = "Date of Join")]
        public DateTime DateJoined { get; set; }
        [Required(ErrorMessage ="Job Role Required"), StringLength(100)]
        public string Designation { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.PhoneNumber), StringLength(14), Display(Name = "Phone Number")]

        public string PhoneNo { get; set; }
        
        public string UAN { get; set; }
        [Display(Name ="Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Student Loan")]
        public StudentLoan StudentLoan { get; set; }
        [Display(Name = "Union Member")]
        public UnionMember UnionMember { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "City name is Required"), StringLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage ="Postcode is Required"), StringLength(50)]

        public string Postcode { get; set; }
        
    }
}

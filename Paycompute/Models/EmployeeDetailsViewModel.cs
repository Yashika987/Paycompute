using Paycompute.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Paycompute.Models
{
    public class EmployeeDetailsViewModel
    {
        public int ID { get; set; }

       
        public string EmployeeNo { get; set; }
        public string FullName { get; set; }

        public string Gender { get; set; }
       
        public string ImageUrl { get; set; }
       
        public DateTime DOB { get; set; }
       
        public DateTime DateJoined { get; set; }
       
        public string Designation { get; set; }
       
        public string Email { get; set; }
       
        public string PhoneNo { get; set; }
 
        public string UAN { get; set; }
      
        public PaymentMethod PaymentMethod { get; set; }
        [Display(Name = "Student Loan")]
        public StudentLoan StudentLoan { get; set; }
        [Display(Name = "Union Member")]
        public UnionMember UnionMember { get; set; }
        public string Address { get; set; }
        
        public string City { get; set; }
        

        public string Postcode { get; set; }
    }
}

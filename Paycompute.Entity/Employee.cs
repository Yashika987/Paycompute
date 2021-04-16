using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Paycompute.Entity
{
    public class Employee
    {
        public int ID { get; set; }

        [Required]
        public string EmployeeNo { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateJoined { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required, MaxLength(50)]
        public string UAN { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public StudentLoan StudentLoan { get; set; }
        public UnionMember UnionMember { get; set; }
        public string Address { get; set; }
        [Required, MaxLength(50)]
        public string City { get; set; }
        [Required, MaxLength(50)]

        public string Postcode { get; set; }
        public IEnumerable<PaymentRecord> PymentRecord { get; set; }
    }
}

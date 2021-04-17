using Microsoft.EntityFrameworkCore;
using Paycompute.Entity;
using Paycompute.Persistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace Paycompute.Services.Implementation
{

    public class EmployeeService : IEmployeeService
    {
       
        private readonly ApplicationDbContext _context;
        private decimal studentLoanAmount;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Employee newEmployee)
        {
          await  _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int employeeId)
        {
            var employee = GetById(employeeId);
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAll() => _context.Employees;
        

        public Employee GetById(int employeeId) => 
            _context.Employees.Where(e=>e.ID == employeeId).FirstOrDefault();
        
        public decimal StudentLoanRepaymentAmount(int id, decimal totalAmount)
        {
            decimal loanRate = .20m;
            var employee = GetById(id);
            if (employee.StudentLoan == StudentLoan.Yes)
            {
                studentLoanAmount = totalAmount * loanRate;
            }
            else
            {
                studentLoanAmount = 0m;
            }
            return studentLoanAmount;
        }

        public decimal UnionFees(int id)
        {
            var employee = GetById(id);
            var fee = employee.UnionMember == UnionMember.Yes ? 50m : 0m;
            return fee;
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var employee = GetById(id);
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<SelectListItem> GetAllEmployeesForPayroll()
        {
            return GetAll().Select(emp => new SelectListItem()
            {
                Text = emp.FullName,
                Value = emp.ID.ToString()
            });
        }
    }
}

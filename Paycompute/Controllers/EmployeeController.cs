using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Paycompute.Entity;
using Paycompute.Models;
using Paycompute.Services;

namespace Paycompute.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly HostingEnvironment _hostingEnvironment;

        public EmployeeController(IEmployeeService employeeService, HostingEnvironment hostingEnvironment)
        {
            _employeeService = employeeService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var employees = _employeeService.GetAll().Select(employee => new EmployeeIndexViewModel
            {
                Id = employee.ID,
                EmployeeNo=employee.EmployeeNo,
                ImageUrl=employee.ImageUrl,
                FullName=employee.FullName,
                Gender=employee.Gender,
                Designation=employee.Designation,
                City=employee.City,
                DateJoined=employee.DateJoined

            }).ToList();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new EmployeeCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //Prevents cross-site Request Forgery Attacks
        public  async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                ID=model.ID,
                EmployeeNo=model.EmployeeNo,
                FirstName=model.FirstName,
                LastName=model.LastName,
                FullName=model.FullName,
                Gender=model.Gender,
                Email=model.Email,
                DOB=model.DOB,
                DateJoined=model.DateJoined,
                UAN=model.UAN,
                PaymentMethod=model.PaymentMethod,
                StudentLoan=model.StudentLoan,
                UnionMember=model.UnionMember,
                Address=model.Address,
                City=model.City,
                Postcode=model.Postcode,
                Designation=model.Designation,
                PhoneNo=model.PhoneNo
                };
                if (model.ImageUrl !=null && model.ImageUrl.Length>0)
                {
                    var uploadDir = @"images/employee";
                    var fileName = Path.GetFileNameWithoutExtension((model.ImageUrl));
                    var extension = Path.GetExtension(model.ImageUrl);
                    var webRootPath = _hostingEnvironment.ContentRootPath;
                     fileName = DateTime.UtcNow.ToString("yymmssfff")+fileName+extension;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    //await  model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + fileName;

                }
                await _employeeService.CreateAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}

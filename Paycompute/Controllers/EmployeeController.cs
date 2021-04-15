﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paycompute.Models;
using Paycompute.Services;

namespace Paycompute.Controllers
{
    public class EmployeeController:Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employee = _employeeService.GetAll().Select(employee => new EmployeeIndexViewModel
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
            return View();
        }
    }
}
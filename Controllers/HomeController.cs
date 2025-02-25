﻿using EmployeeManagement.DAL.Interfaces;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public ViewResult Index()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return View(employees);
        }
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel viewModel = new()
            {
                Employee = _employeeRepository.GetEmployeeById(id ?? 1),
                PageTitle = "Employee Details"
            };
            return View(viewModel); //To pass data to view
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.AddEmployee(employee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
    }
}

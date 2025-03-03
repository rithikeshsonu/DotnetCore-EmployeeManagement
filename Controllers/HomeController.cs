using EmployeeManagement.DAL.Interfaces;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public HomeController(IEmployeeRepository employeeRepository, IWebHostEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
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
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo!= null)
                {
                    //foreach(IFormFile photo in model.Photos)
                    //{
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                //}

                Employee newEmployee = new()
                {
                    Name = model.Name,
                    Department = model.Department,
                    Email = model.Email,
                    PhotoPath = uniqueFileName
                };
                _employeeRepository.AddEmployee(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);
            EmployeeEditViewModel employeeEditViewModel = new()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath,
            };
            
            return View(employeeEditViewModel);
        }
    }
}

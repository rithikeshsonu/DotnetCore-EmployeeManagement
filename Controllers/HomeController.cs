using EmployeeManagement.DAL.Interfaces;
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
        public ViewResult Details()
        {
            HomeDetailsViewModel viewModel = new()
            {
                Employee = _employeeRepository.GetEmployeeById(1),
                PageTitle = "Employee Details"
            };
            return View(viewModel); //To pass data to view
        }
    }
}

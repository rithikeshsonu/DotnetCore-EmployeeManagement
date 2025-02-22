using EmployeeManagement.DAL.Interfaces;
using EmployeeManagement.Models;
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
        public string Index()
        {
            return _employeeRepository.GetEmployeeById(1).Name;
        }
        public ViewResult Details()
        {
            Employee employee = _employeeRepository.GetEmployeeById(1);
            return View(employee);
        }
    }
}

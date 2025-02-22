using EmployeeManagement.DAL.Interfaces;
using EmployeeManagement.Models;

namespace EmployeeManagement.DAL.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public EmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new() {Id = 1, Name ="Mary", Department = "HR", Email = "Mary@gmail.com"},
                new() {Id = 2, Name ="Sonu", Department = "Tech", Email = "Sonu@gmail.com"},
                new() {Id = 3, Name ="John", Department = "IT", Email = "John@gmail.com"}
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == id);
        }
    }
}

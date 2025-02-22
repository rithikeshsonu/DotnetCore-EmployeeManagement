using EmployeeManagement.Models;

namespace EmployeeManagement.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
        IEnumerable<Employee> GetAllEmployees();
    }
}

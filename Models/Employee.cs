using System.ComponentModel.DataAnnotations;
namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Name must not exceed 50 chars")]
        public string Name { get; set; } = string.Empty;
        [Required, Display(Name = "Office Email"), RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;
        public Dept Department { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    Name = "Mark",
                    Department = Dept.IT,
                    Email = "sonu@gmail.com",
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Sonu",
                    Department = Dept.HR,
                    Email = "mark@ymail.com"
                },
                new Employee()
                {
                    Id = 3,
                    Name = "John",
                    Department = Dept.Payroll,
                    Email = "john@ymail.com"
                },
                new Employee()
                {
                    Id = 4,
                    Name = "Test",
                    Department = Dept.IT,
                    Email = "Test@gmail.com"
                }
            );
        }
    }
}

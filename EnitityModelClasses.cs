using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeJob { get; set; }
        public string EmployeeDep { get; set; }

        public int EmployeeSalary { get; set; }
    }


    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }

    }

    public class DetailsDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<User> Users { get; set; }

        public DetailsDbContext(DbContextOptions<DetailsDbContext> options)
         : base(options)
        {

        }
    }



}

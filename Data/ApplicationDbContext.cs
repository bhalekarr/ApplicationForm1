using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RahulApp.Models;

namespace RahulApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<RahulApp.Models.AddEmpViewModel>? AddEmpViewModel { get; set; }

        public DbSet<RahulApp.Models.EditEmployeeViewModel>? EditEmployeeViewModel { get; set; }
    }
}
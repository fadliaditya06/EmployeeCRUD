using Microsoft.EntityFrameworkCore;
using EmployeeCRUD.Models;

namespace EmployeeCRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<EmployeeDept> EmployeeDepts { get; set; }

        public DbSet<EmployeeViewModel> EmployeeDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeViewModel>().ToView("vw_EmployeeDetails").HasNoKey();

            modelBuilder.Entity<EmployeeDept>().HasKey(ed => ed.SESA_ID);
        }
    }
}
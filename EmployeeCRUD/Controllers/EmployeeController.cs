using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeCRUD.Data;
using EmployeeCRUD.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _context.EmployeeDetails.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<JsonResult> Get(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return Json(new { success = false });

            var empDept = await _context.EmployeeDepts.FindAsync(id);
            var formModel = new EmployeeFormModel
            {
                SESA_ID = employee.SESA_ID,
                Name = employee.Name,
                Birth_date = employee.Birth_date,
                Gender = employee.Gender,
                Department_code = empDept?.Department_code
            };
            return Json(new { success = true, data = formModel });
        }

        [HttpPost]
        public async Task<JsonResult> Save(EmployeeFormModel model)
        {
            if (ModelState.IsValid)
            {
                var employeeInDb = await _context.Employees.FindAsync(model.SESA_ID);

                if (employeeInDb != null) 
                {
                    employeeInDb.Name = model.Name;
                    employeeInDb.Birth_date = model.Birth_date;
                    employeeInDb.Gender = model.Gender;

                    var empDeptInDb = await _context.EmployeeDepts.FindAsync(model.SESA_ID);
                    if (empDeptInDb != null)
                    {
                        empDeptInDb.Department_code = model.Department_code;
                    }
                }
                else 
                {
                    var employee = new Employee
                    {
                        SESA_ID = model.SESA_ID,
                        Name = model.Name,
                        Birth_date = model.Birth_date,
                        Gender = model.Gender
                    };
                    _context.Employees.Add(employee);

                    var empDept = new EmployeeDept
                    {
                        SESA_ID = model.SESA_ID,
                        Department_code = model.Department_code
                    };
                    _context.EmployeeDepts.Add(empDept);
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                        .Select(e => e.ErrorMessage)
                                        .Where(msg => !string.IsNullOrEmpty(msg))
                                        .ToList();

            var message = "Data tidak valid:\n- " + string.Join("\n- ", errors);
            return Json(new { success = false, message = message });
        }


        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return Json(new { success = false, message = "Data tidak ditemukan." });

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }
    }
}

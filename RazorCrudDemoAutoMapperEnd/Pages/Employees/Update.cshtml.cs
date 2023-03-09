using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrudDemo_FACIT.Data;
using RazorCrudDemo_FACIT.Data.Viewmodels;

namespace RazorCrudDemo_FACIT.Pages.Employees
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public UpdateEmployeeViewModel UpdateEmployeeVM { get; set; }

        private readonly ApplicationDbContext _dbContext;

        public UpdateModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet(Guid id)
        {
            var employeeDB = _dbContext.Employees.Find(id);

            if (employeeDB != null)
            {
                UpdateEmployeeVM = new UpdateEmployeeViewModel()
                {
                    Id = employeeDB.Id,
                    Name = employeeDB.Name,
                    Email = employeeDB.Email,
                    DateOfBirth = employeeDB.DateOfBirth,
                    Salary = employeeDB.Salary,
                    Department = employeeDB.Department
                };
            }
        }
        public void OnPost()
        {
            var employeeToUpdateDB = _dbContext.Employees.Find(UpdateEmployeeVM.Id);

            if (ModelState.IsValid)
            {
                // Mappar från ViewModel till DB Model
                employeeToUpdateDB.Name = UpdateEmployeeVM.Name;
                employeeToUpdateDB.Email = UpdateEmployeeVM.Email;
                employeeToUpdateDB.Salary = UpdateEmployeeVM.Salary;
                employeeToUpdateDB.DateOfBirth = UpdateEmployeeVM.DateOfBirth;
                employeeToUpdateDB.Department = UpdateEmployeeVM.Department;

                _dbContext.SaveChanges();

                ViewData["Message"] = "Employee updated successfully!";
            }
        }

        public IActionResult OnPostDelete()
        {
            var employeeToDeleteDB = _dbContext.Employees.Find(UpdateEmployeeVM.Id);

            if (employeeToDeleteDB != null)
            {
                _dbContext.Employees.Remove(employeeToDeleteDB);
                _dbContext.SaveChanges();

                return RedirectToPage("/Employees/Read");
            }

            return Page();
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrudDemo_FACIT.Data;
using RazorCrudDemo_FACIT.Data.Viewmodels;

namespace RazorCrudDemo_FACIT.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;

        public CreateModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public CreateEmployeeViewModel CreateEmployeeRequest { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var employeeDbModel = new Employee
            {
                Name = CreateEmployeeRequest.Name,
                Email = CreateEmployeeRequest.Email,
                Salary = CreateEmployeeRequest.Salary,
                DateOfBirth = CreateEmployeeRequest.DateOfBirth,
                Department = CreateEmployeeRequest.Department
            };

            dbContext.Employees.Add(employeeDbModel);
            dbContext.SaveChanges();

            ViewData["Message"] = "Employee created successfully!";
        }

    }

}

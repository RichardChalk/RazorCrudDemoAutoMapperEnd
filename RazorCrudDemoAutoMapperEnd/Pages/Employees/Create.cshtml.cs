using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrudDemo_FACIT.Data;
using RazorCrudDemo_FACIT.Data.Viewmodels;

namespace RazorCrudDemo_FACIT.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CreateModel(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [BindProperty]
        public CreateEmployeeViewModel CreateEmployeeRequest { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            //var employeeDbModel = new Employee
            //{
            //    Name = CreateEmployeeRequest.Name,
            //    Email = CreateEmployeeRequest.Email,
            //    Salary = CreateEmployeeRequest.Salary,
            //    DateOfBirth = CreateEmployeeRequest.DateOfBirth,
            //    Department = CreateEmployeeRequest.Department
            //};

            // Automapper kommer att mappa samtliga properties med SAMMA NAMN!
            // I detta fall mappar vi FRÅN Frontend (ViewModel) TO databaseb (entitet)
            var employeeDbModel = new Employee();
            mapper.Map(CreateEmployeeRequest, employeeDbModel);

            dbContext.Employees.Add(employeeDbModel);
            dbContext.SaveChanges();

            ViewData["Message"] = "Employee created successfully!";
        }
    }
}

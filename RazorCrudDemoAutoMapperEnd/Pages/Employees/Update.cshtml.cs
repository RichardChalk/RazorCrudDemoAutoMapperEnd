using AutoMapper;
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
        private readonly IMapper _mapper;

        public UpdateModel(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void OnGet(Guid id)
        {
            var employeeDB = _dbContext.Employees.Find(id);

            if (employeeDB != null)
            {
                //UpdateEmployeeVM = new UpdateEmployeeViewModel()
                //{
                //    Id = employeeDB.Id,
                //    Name = employeeDB.Name,
                //    Email = employeeDB.Email,
                //    DateOfBirth = employeeDB.DateOfBirth,
                //    Salary = employeeDB.Salary,
                //    Department = employeeDB.Department
                //};

                // Automapper kommer att mappa samtliga properties med SAMMA NAMN!
                // I detta fall mappar vi FRÅN database TO Frontend (ViewModel)
                UpdateEmployeeVM = new UpdateEmployeeViewModel();
                _mapper.Map(employeeDB, UpdateEmployeeVM);
            }
        }
        public void OnPost()
        {
            var employeeToUpdateDB = _dbContext.Employees.Find(UpdateEmployeeVM.Id);

            if (ModelState.IsValid)
            {
                // Mappar från ViewModel till DB Model
                //employeeToUpdateDB.Name = UpdateEmployeeVM.Name;
                //employeeToUpdateDB.Email = UpdateEmployeeVM.Email;
                //employeeToUpdateDB.Salary = UpdateEmployeeVM.Salary;
                //employeeToUpdateDB.DateOfBirth = UpdateEmployeeVM.DateOfBirth;
                //employeeToUpdateDB.Department = UpdateEmployeeVM.Department;

                // Automapper kommer att mappa samtliga properties med SAMMA NAMN!
                // I detta fall mappar vi FRÅN Frontend (ViewModel) TO database
                _mapper.Map(UpdateEmployeeVM, employeeToUpdateDB);

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

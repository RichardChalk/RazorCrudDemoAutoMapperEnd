using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCrudDemo_FACIT.Data;

namespace RazorCrudDemo_FACIT.Pages.Employees
{
    public class ReadModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        public string ShortDate { get; set; } // Övning1

        public List<Employee> Employees { get; set; }

        public ReadModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
            Employees = _dbContext.Employees.ToList();
            var date = DateTime.UtcNow; // Övning1
            ShortDate = date.ToShortDateString(); // Övning1
        }
    }

}

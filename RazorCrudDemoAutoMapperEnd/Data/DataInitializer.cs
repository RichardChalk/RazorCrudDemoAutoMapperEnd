using Microsoft.EntityFrameworkCore;

namespace RazorCrudDemo_FACIT.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MigrateData()
        {
            _dbContext.Database.Migrate();
            SeedData();
            _dbContext.SaveChanges();
        }

        private void SeedData()
        {
            if (!_dbContext.Employees.Any(e => e.Name == "Richard"))
            {
                _dbContext.Add(new Employee
                {
                    Name = "Richard",
                    Email = "richard@email.com",
                    Salary = 55000,
                    DateOfBirth = new DateTime(1970 - 05 - 21),
                    Department = "KYH"
                });
            }
        }
    }
}

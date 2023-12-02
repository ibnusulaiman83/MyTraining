using Microsoft.EntityFrameworkCore;
using MyTraining.Models.Domain;

namespace MyTraining.Data
{
    public class MyTrainingDbContext : DbContext
    {
        public MyTrainingDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}

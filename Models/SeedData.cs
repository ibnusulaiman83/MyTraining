using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyTraining.Data;
using System;
using System.Linq;
using MyTraining.Models;
using MyTraining.Models.Domain;

namespace MyTraining.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new MyTrainingDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MyTrainingDbContext>>())) {

                // Look for any employee.
                if (context.Employees.Any())
                {
                    return;   // DB has been seeded
                }

                context.Employees.AddRange(
                    new Employee { 
                        Name= "Jalaluddin Hassan",
                        Department = "HR",
                        BirthDay = DateTime.Parse("10/11/1990")
                    },
                    new Employee
                    {
                        Name = "Amiruddin Saari",
                        Department = "IT",
                        BirthDay = DateTime.Parse("10/11/1990")
                    },
                    new Employee
                    {
                        Name = "Wong Ah fook",
                        Department = "Security",
                        BirthDay = DateTime.Parse("10/09/1990")
                    }
                );
                context.SaveChanges();
            }


        }
    }
}

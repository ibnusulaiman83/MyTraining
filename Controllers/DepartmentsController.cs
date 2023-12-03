using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTraining.Data;
using MyTraining.Models;
using MyTraining.Models.Domain;

namespace MyTraining.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly MyTrainingDbContext myTrainingDbContext;

        public DepartmentsController(MyTrainingDbContext myTrainingDbContext)
        {
            this.myTrainingDbContext = myTrainingDbContext;
        }


        public async Task<IActionResult> Index()
        {
            var departments = await myTrainingDbContext.Departments.ToListAsync();
            return View(departments);
        }
    }
}

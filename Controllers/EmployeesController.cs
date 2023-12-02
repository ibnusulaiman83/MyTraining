using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTraining.Data;
using MyTraining.Models;
using MyTraining.Models.Domain;


namespace MyTraining.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MyTrainingDbContext myTrainingDbContext;

        public EmployeesController(MyTrainingDbContext myTrainingDbContext)
        {
            this.myTrainingDbContext = myTrainingDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           var employees = await myTrainingDbContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                BirthDay = addEmployeeRequest.BirthDay,
                Department = addEmployeeRequest.Department
            };

            await myTrainingDbContext.Employees.AddAsync(employee);
            await myTrainingDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
           var employee = await myTrainingDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    BirthDay = employee.BirthDay,
                    Department = employee.Department
                };

                return await Task.Run(() => View("View", viewModel));

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel updateEmployeeRequest)
        { 
            var employee = await myTrainingDbContext.Employees.FindAsync(updateEmployeeRequest.Id);

            if (employee != null)
            {
                employee.Name =  updateEmployeeRequest.Name;
                employee.Department = updateEmployeeRequest.Department;
                employee.BirthDay = updateEmployeeRequest.BirthDay;
                await myTrainingDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
         public async Task<IActionResult> Delete (UpdateEmployeeViewModel model)
        {
            var employee = await myTrainingDbContext.Employees.FindAsync(model.Id);

            if (employee != null)
            {
                myTrainingDbContext.Employees.Remove(employee);
                await myTrainingDbContext.SaveChangesAsync();   

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


    }
}

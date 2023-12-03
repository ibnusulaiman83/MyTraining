using MyTraining.Models.Domain;

namespace MyTraining.Models
{
    public class EmployeeViewModel
    {
        public Employee empVm { get; set; }
        public List<Department> deptList { get; set;}
    }
}

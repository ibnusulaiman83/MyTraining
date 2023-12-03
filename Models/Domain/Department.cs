using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyTraining.Models.Domain
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [DisplayName( "Department Name")]
        public string DepartmentName { get; set; }
    }
}

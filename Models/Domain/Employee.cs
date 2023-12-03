using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace MyTraining.Models.Domain
{
    public class Employee
    {
        public Guid  Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Department { get; set; }
        
    }
}

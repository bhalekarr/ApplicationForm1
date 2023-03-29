using System.ComponentModel.DataAnnotations;

namespace RahulApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

         
        public string Name { get; set; }

        public int? Age { get; set; }
  
        public string? Gender { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }
        
        public string Country { get; set; }
        
        public string State { get; set; }
        
        public string? Photo { get; set; }
    }
}

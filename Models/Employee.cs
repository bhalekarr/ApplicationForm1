using System.ComponentModel.DataAnnotations;

namespace RahulApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

         
        public string Name { get; set; }

        //[Required(ErrorMessage ="Age is required")]
        //[Range(18, 100, ErrorMessage ="Age should be 18 to 100 years")]
        public int? Age { get; set; }
//
        //[Required(ErrorMessage ="Select Gender")]
        public string? Gender { get; set; }

        //[Required(ErrorMessage ="Email is required")]
        //[DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        //[Required(ErrorMessage ="Phone Number is required")]
        public string? PhoneNumber { get; set; }
        
        public string? Country { get; set; }
        
        public string? State { get; set; }
        
        public string? Photo { get; set; }
    }
}

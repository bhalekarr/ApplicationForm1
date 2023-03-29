using System.ComponentModel.DataAnnotations;

namespace RahulApp.Models
{
    public class AddEmpViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

         
        [Range(18, 100, ErrorMessage = "Age should be 18 to 100 years")]
        public int? Age { get; set; }

        public string? Gender { get; set; }

        
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

       
        [MaxLength(10, ErrorMessage = "Phone number should be 10 digits")]
        //[DataType(DataType.PhoneNumber)]
        [Display(Name ="Phone Number")]
        public string? PhoneNumber { get; set; }

        public int CountryId { get; set; }
        public string? Country { get; set; }

        public int StateId { get; set; }
        public string? State { get; set; }

        public string? Photo { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PL.DTOs
{
    public class CreateEmployeeDTO
    {
        [Required(ErrorMessage = "Code Is Required")]
        public int Code { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address Is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Salary Is Required")]
        public int Salary { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PL.DTOs
{
    public class CreateDepartmentDTO
    {
        [Required(ErrorMessage = "Code Is Required")]
        public int Code { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CreateTime Is Required")]
        public DateTime CreatedDate { get; set; }
    }
}

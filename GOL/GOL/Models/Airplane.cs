using GOL.CustomValidators;
using System;
using System.ComponentModel.DataAnnotations;

namespace GOL.Models
{
    public class Airplane : BaseEntity
    {
        [Required]
        public string Code { get; set; }

        [Required]
        //[ModelValidate(Allowed = new string[] { "Model1", "Model2", "Model3" }, ErrorMessage = "Modelo Inválido")]
        public string Model { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}

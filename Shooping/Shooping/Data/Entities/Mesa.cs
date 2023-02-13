using Shooping.Enums;
using System.ComponentModel.DataAnnotations;


namespace Shooping.Data.Entities
{
    public class Mesa
    {
        public int Id { get; set; }

        [Display(Name = "Mesa")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }


        [Display(Name = "Estado")]
        public MesaStatus MesaStatus { get; set; }
    }
}

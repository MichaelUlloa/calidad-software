using System.ComponentModel.DataAnnotations;

namespace Shooping.Data.Entities
{
    public class Suplidores
    {
        public int Id { get; set; }


        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }



        [Required]
        [MaxLength(50)]
        [Display(Name = "Correo ")]
        public string Correo { get; set; }


        [Display(Name = "Ciudad")]
        public City City { get; set; }
    }
}

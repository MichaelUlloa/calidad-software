using System.ComponentModel.DataAnnotations;

namespace Shooping.Data.Entities
{
    public class Resevaciones
    {
        public int Id { get; set; }

        public User User { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime Date { get; set; }


        public Mesa Mesa { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Comentarios")]
        public string Remarks { get; set; }
    }
}

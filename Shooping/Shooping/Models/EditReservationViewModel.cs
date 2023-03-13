using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shooping.Models;

public class EditReservationViewModel
{
    public int Id { get; set; }

    [Display(Name = "Documento")]
    [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string Document { get; set; }

    [Display(Name = "Nombre Completo")]
    [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string FullName { get; set; }

    [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
    [Display(Name = "Fecha")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public DateTime Date { get; set; }

    [DataType(DataType.MultilineText)]
    [Display(Name = "Comentarios")]
    public string Remarks { get; set; }

    [Display(Name = "Mesa")]
    [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una mesa.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public int TableId { get; set; }

    public IEnumerable<SelectListItem> Tables { get; set; }
}
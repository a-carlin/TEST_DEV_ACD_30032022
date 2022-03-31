using System;
using System.ComponentModel.DataAnnotations;

namespace Test.Web.Models
{
    public class PersonaFisicaViewModel
    {
        public int IdPersonaFisica { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        [Required(ErrorMessage ="Debe especificar el nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe especificar el apellido paterno")]
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "Debe especificar el RFC")]
        [StringLength(13)]
        public string RFC { get; set; }
        [Required(ErrorMessage = "Debe especificar la fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? FechaNacimiento { get; set; }
        public int? UsuarioAgrega { get; set; }
        public bool? Activo { get; set; }
    }
}

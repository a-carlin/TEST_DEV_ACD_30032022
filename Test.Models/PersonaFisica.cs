using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Test.Models
{
    public class PersonaFisica
    {
        public int IdPersonaFisica { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        [Required(ErrorMessage = "Debe especificar el nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe especificar el apellido paterno")]
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "Debe especificar el apellido paterno")]
        public string RFC { get; set; }
        [Required(ErrorMessage = "Debe especificar la fecha de nacimiento")]
        public DateTime? FechaNacimiento { get; set; }
        public int? UsuarioAgrega { get; set; }
        public bool? Activo { get; set; }
    }
}

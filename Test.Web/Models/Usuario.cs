using System;
using System.ComponentModel.DataAnnotations;
using Test.Web.Attributes;

namespace Test.Web.Models
{
    public class Usuario
    {
        public Guid IdUsuario { get; set; }
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        [DataType(DataType.Password)]
        //[ContrasenaValidate(ErrorMessage = "Contraseña no válida")]
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}

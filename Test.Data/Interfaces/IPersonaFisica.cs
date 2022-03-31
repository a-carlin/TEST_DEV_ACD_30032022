using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Data.Interfaces
{
    public interface IPersonaFisica
    {
        Task Actualizar(PersonaFisica personaFisica);
        Task<IEnumerable<PersonaFisica>> ObtenerPersonasFisicas();
        Task Crear(PersonaFisica personaFisica);
        Task Eliminar(int idPersonaFisica);
        Task<PersonaFisica> ObtenerPorId(int IdPersonaFisica);
    }
}

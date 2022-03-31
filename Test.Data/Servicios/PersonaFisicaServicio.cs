using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Interfaces;
using Test.Data.Repositorio;
using Test.Models;

namespace Test.Data.Servicios
{
    public class PersonaFisicaServicio : IPersonaFisica
    {
        private readonly ContextTest _contexto;
        public PersonaFisicaServicio(ContextTest contexto)
        {
            _contexto = contexto;
        }
        public async Task Crear(PersonaFisica personaFisica)
        {
            var newPersonaFisica = new PersonaFisica();
            newPersonaFisica.Nombre = personaFisica.Nombre;
            newPersonaFisica.ApellidoPaterno = personaFisica.ApellidoPaterno;
            newPersonaFisica.ApellidoMaterno = personaFisica.ApellidoMaterno;
            newPersonaFisica.RFC = personaFisica.RFC;
            newPersonaFisica.FechaNacimiento = personaFisica.FechaNacimiento;
            newPersonaFisica.UsuarioAgrega = personaFisica.UsuarioAgrega;

            await _contexto.CrearPersonaFisicaAsync(newPersonaFisica);

        }
        public async Task Actualizar(PersonaFisica personaFisica)
        {
            var dbPersonaFisica = await _contexto.Tb_PersonasFisicas.FindAsync(personaFisica.IdPersonaFisica);
            if (dbPersonaFisica != null)
            {
                dbPersonaFisica.IdPersonaFisica = personaFisica.IdPersonaFisica;
                dbPersonaFisica.Nombre = personaFisica.Nombre;
                dbPersonaFisica.ApellidoPaterno = personaFisica.ApellidoPaterno;
                dbPersonaFisica.ApellidoMaterno = personaFisica.ApellidoMaterno;
                dbPersonaFisica.RFC = personaFisica.RFC;
                dbPersonaFisica.FechaNacimiento = personaFisica.FechaNacimiento;
                dbPersonaFisica.UsuarioAgrega = personaFisica.UsuarioAgrega;
            }

            await _contexto.ActualizarPersonaFisicaAsync(dbPersonaFisica);

        }

        public async Task Eliminar(int IdPersonaFisica)
        {
            var dbPersonaFisica = await _contexto.Tb_PersonasFisicas.FindAsync(IdPersonaFisica);
            if (dbPersonaFisica != null)
            {
                await _contexto.EliminarPersonaFisicaAsync(IdPersonaFisica);
            }

        }

        public async Task<PersonaFisica> ObtenerPorId(int IdPersonaFisica)
        {
            PersonaFisica personaFisica = new PersonaFisica();
            var dbPersonaFisica = await _contexto.Tb_PersonasFisicas.FindAsync(IdPersonaFisica);
            if (dbPersonaFisica == null)
            {
                return null;
            }

            personaFisica.IdPersonaFisica = dbPersonaFisica.IdPersonaFisica;
            personaFisica.Nombre = dbPersonaFisica.Nombre;
            personaFisica.ApellidoPaterno = dbPersonaFisica.ApellidoPaterno;
            personaFisica.ApellidoMaterno = dbPersonaFisica.ApellidoMaterno;
            personaFisica.RFC = dbPersonaFisica.RFC;
            personaFisica.FechaRegistro = dbPersonaFisica.FechaRegistro;
            personaFisica.FechaActualizacion = dbPersonaFisica.FechaActualizacion;
            personaFisica.FechaNacimiento = dbPersonaFisica.FechaNacimiento;
            personaFisica.UsuarioAgrega = dbPersonaFisica.UsuarioAgrega;
            personaFisica.Activo = dbPersonaFisica.Activo;


            return personaFisica;
        }
        public async  Task<IEnumerable<PersonaFisica>> ObtenerPersonasFisicas()
        {
            var data = await _contexto.Tb_PersonasFisicas.ToListAsync();
            var personasFisicas = data.Select(a => new PersonaFisica
            {
                IdPersonaFisica = a.IdPersonaFisica,
                Nombre = a.Nombre,
                ApellidoPaterno = a.ApellidoPaterno,
                ApellidoMaterno = a.ApellidoMaterno,
                RFC = a.RFC,
                FechaNacimiento = a.FechaNacimiento,
                FechaRegistro = a.FechaRegistro,
                FechaActualizacion = a.FechaActualizacion,
                UsuarioAgrega = a.UsuarioAgrega,
                Activo = a.Activo
            });
            return personasFisicas;
        }

    }
}

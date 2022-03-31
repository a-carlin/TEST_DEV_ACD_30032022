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
    public class AuthServicio : IAuth
    {
        private readonly ContextTest _contexto;
        public AuthServicio(ContextTest contexto)
        {
            _contexto = contexto;
        }
        public async Task<Usuario> Login(Usuario usuario)
        {
            Usuario usuarioModel = new Usuario();
            var dbUsuario = await _contexto.Tb_Usuario.ToListAsync();
            var usuarioFilter = dbUsuario.Where(a => a.Correo == usuario.Correo && a.Contrasena == usuario.Contrasena).FirstOrDefault();

            if (usuarioFilter != null)
            {
                if (usuarioFilter.Correo.Equals(usuario.Correo) && usuarioFilter.Contrasena.Equals(usuario.Contrasena))
                {
                    usuarioModel.IdUsuario = usuarioFilter.IdUsuario;
                    usuarioModel.Correo = usuarioFilter.Correo;
                    usuarioModel.Nombre = usuarioFilter.Nombre;
                    usuarioModel.ApellidoPaterno = usuarioFilter.ApellidoPaterno;
                    usuarioModel.ApellidoMaterno = usuarioFilter.ApellidoMaterno;
                }
                else
                {
                    return null;
                }
                
            }
            else
            {
                return null; 
            }
            return (usuarioModel);
        }

    }
}

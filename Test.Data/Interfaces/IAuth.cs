using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Data.Interfaces
{
    public interface IAuth
    {
        Task<Usuario> Login(Usuario usuario);
    }
}

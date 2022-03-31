using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Test.Models;
using Test.Models.Excepciones;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Data.Repositorio
{
    public partial class ContextTest : DbContext
    {
        public ContextTest()
        {
        }

        public ContextTest(DbContextOptions<ContextTest> options)
            : base(options)
        {
        }

        public virtual DbSet<Tb_PersonasFisicas> Tb_PersonasFisicas { get; set; }
        public virtual DbSet<Tb_Usuario> Tb_Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Test;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tb_PersonasFisicas>(entity =>
            {
                entity.HasKey(e => e.IdPersonaFisica);

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RFC)
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tb_Usuario>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public async Task CrearPersonaFisicaAsync(PersonaFisica personaFisica)
        {
            try
            {
                var param1 = new SqlParameter("Nombre", personaFisica.Nombre);
                var param2 = new SqlParameter("ApellidoPaterno", personaFisica.ApellidoPaterno);
                var param3 = new SqlParameter("ApellidoMaterno", (object)personaFisica.ApellidoMaterno ?? DBNull.Value);
                var param4 = new SqlParameter("RFC", personaFisica.RFC);
                var param5 = new SqlParameter("FechaNacimiento", personaFisica.FechaNacimiento);
                var param6 = new SqlParameter("UsuarioAgrega", (object)personaFisica.UsuarioAgrega ?? DBNull.Value);

                string sqlQuery = "EXEC [dbo].[sp_AgregarPersonaFisica] @Nombre = @Nombre, @ApellidoPaterno = @ApellidoPaterno, @ApellidoMaterno = @ApellidoMaterno, @RFC = @RFC, @FechaNacimiento = @FechaNacimiento, @UsuarioAgrega = @UsuarioAgrega";
                await Database.ExecuteSqlRawAsync(sqlQuery, param1, param2, param3, param4, param5, param6);

            }
            catch (Exception ex)
            {

                throw new HttpStatusCodeException(500, ex.Message);
            }
        }
        public async Task ActualizarPersonaFisicaAsync(Tb_PersonasFisicas personaFisica)
        {
            try
            {
                var param1 = new SqlParameter("IdPersonaFisica", personaFisica.IdPersonaFisica);
                var param2 = new SqlParameter("Nombre", personaFisica.Nombre);
                var param3 = new SqlParameter("ApellidoPaterno", personaFisica.ApellidoPaterno);
                var param4 = new SqlParameter("ApellidoMaterno", (object)personaFisica.ApellidoMaterno ?? DBNull.Value);
                var param5 = new SqlParameter("RFC", personaFisica.RFC);
                var param6 = new SqlParameter("FechaNacimiento", personaFisica.FechaNacimiento);
                var param7 = new SqlParameter("UsuarioAgrega", (object)personaFisica.UsuarioAgrega ?? DBNull.Value);

                string sqlQuery = "EXEC [dbo].[sp_ActualizarPersonaFisica] @IdPersonaFisica = @IdPersonaFisica, @Nombre = @Nombre, @ApellidoPaterno = @ApellidoPaterno, @ApellidoMaterno = @ApellidoMaterno, @RFC = @RFC, @FechaNacimiento = @FechaNacimiento, @UsuarioAgrega = @UsuarioAgrega";
                var result = await Database.ExecuteSqlRawAsync(sqlQuery, param1, param2, param3, param4, param5, param6, param7);
            }
            catch (Exception ex)
            {

                throw new HttpStatusCodeException(500, ex.Message);
            }
        }
        public async Task EliminarPersonaFisicaAsync(int idPersonaFisica)
        {
            try
            {
                var param1 = new SqlParameter("IdPersonaFisica", idPersonaFisica);

                string sqlQuery = "EXEC [dbo].[sp_EliminarPersonaFisica] @IdPersonaFisica = @IdPersonaFisica";
                var result = await Database.ExecuteSqlRawAsync(sqlQuery, param1);
            }
            catch (Exception ex)
            {

                throw new HttpStatusCodeException(500, ex.Message);
            }
        }
    }
}

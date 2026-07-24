using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StaffCoreRD.Models;

namespace StaffCoreRD.Data
{
    public class StaffDbContext : IdentityDbContext<IdentityUser>
    {
        public StaffDbContext(DbContextOptions<StaffDbContext> options) : base(options)
        {
        }

        public DbSet<Staff> Personal { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            // Seed de 2 registros con datos reales dominicanos, departamentos distintos
            mb.Entity<Staff>().HasData(
                new Staff
                {
                    Id = 1,
                    Nombre = "Ramona Altagracia Pérez de la Cruz",
                    Cedula = "001-1234567-8",
                    Cargo = "Analista de Sistemas",
                    Departamento = "Tecnología",
                    Salario = 45000m,
                    FechaIngreso = new DateTime(2022, 3, 15),
                    Activo = true
                },
                new Staff
                {
                    Id = 2,
                    Nombre = "Juan Carlos Rosario Feliz",
                    Cedula = "002-7654321-0",
                    Cargo = "Coordinador de Nómina",
                    Departamento = "Recursos Humanos",
                    Salario = 38000m,
                    FechaIngreso = new DateTime(2021, 7, 1),
                    Activo = true
                }
            );
        }
    }
}
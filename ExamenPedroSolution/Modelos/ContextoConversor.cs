using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ContextoConversor : DbContext 
    {

        public ContextoConversor(DbContextOptions<ContextoConversor> options) : base(options)
        {

        }


        public DbSet<Personas> Personas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Personas>().HasData(
                new Personas()
                {

                    Id = 1,
                    Nombre = "Pedro",
                    FechaNacimiento = new DateTime(1998, 06, 21),
                    Telefono = "948230430",
                    Username = "Paco1",
                    Password = "Contraseña"
                },

                new Personas()
                {
                    Id = 2,
                    Nombre = "Ana",
                    FechaNacimiento = new DateTime(1995, 03, 15),
                    Telefono = "123456789",
                    Username = "Paco2",
                    Password = "Contraseña"
                },
                new Personas()
                {
                    Id = 3,
                    Nombre = "Luis",
                    FechaNacimiento = new DateTime(1990, 11, 30),
                    Telefono = "987654321",
                    Username = "Paco3",
                    Password = "Contraseña"
                },
                new Personas()
                {
                    Id = 4,
                    Nombre = "María",
                    FechaNacimiento = new DateTime(1987, 08, 12),
                    Telefono = "555123789",
                    Username = "Paco4",
                    Password = "Contraseña"
                },
                new Personas()
                {
                    Id = 5,
                    Nombre = "Juan",
                    FechaNacimiento = new DateTime(2005, 04, 05),
                    Telefono = "777888999",
                    Username = "Paco5",
                    Password = "Contraseña"
                },
                new Personas()
                {
                    Id = 6,
                    Nombre = "Laura",
                    FechaNacimiento = new DateTime(2002, 09, 18),
                    Telefono = "333444555",
                    Username = "Paco6",
                    Password = "Contraseña"
                },
                new Personas()
                {
                    Id = 7,
                    Nombre = "Carlos",
                    FechaNacimiento = new DateTime(1978, 12, 03),
                    Telefono = "999111222",
                    Username = "Paco7",
                    Password = "Contraseña"
                },
                 new Personas()
                 {
                     Id = 8,
                     Nombre = "Marta",
                     FechaNacimiento = new DateTime(1983, 07, 27),
                     Telefono = "444555666",
                     Username = "Paco8",
                     Password = "Contraseña"
                 },
                new Personas()
                {
                    Id = 9,
                    Nombre = "Andrés",
                    FechaNacimiento = new DateTime(2000, 01, 10),
                    Telefono = "888999000",
                    Username = "Paco9",
                    Password = "Contraseña"
                },
                new Personas()
                {
                    Id = 10,
                    Nombre = "Isabel",
                    FechaNacimiento = new DateTime(1970, 05, 08),
                    Telefono = "222333444",
                    Username = "Paco10",
                    Password = "Contraseña"
                }


                );

        }



    }
}

using DTOs;
using Entidades;
using Microsoft.EntityFrameworkCore;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Repositorios
{
    public class RepositorioBBDD : IRepositoriosBBDD
    {

        private readonly ContextoConversor db;

        public RepositorioBBDD(ContextoConversor db)
        {
            this.db = db;
        }


        public async Task<IEnumerable<Personas>> GetPersonasAsync()
        {
            return await db.Personas.ToListAsync();
        }

        public async Task<ActionResult<List<PersonasDTO>>> GetPersonasMayoresDe21()
        {

            var personas = await GetPersonasAsync();

            // Obtiene la fecha actual
            var currentDate = DateTime.UtcNow;

            // Filtra las personas mayores de 21 años utilizando GetCurrentAge
            var personasMayoresDe21 = personas.Where(p => p.FechaNacimiento.GetCurrentAge() > 21).ToList();

            // Aquí puedes mapear las personas a DTOs incluyendo la edad
            var personasDTO = personasMayoresDe21.Select(p => new PersonasDTO
            {
                // Mapea las propiedades de Persona a las propiedades de PersonaDTO
                // Por ejemplo:
                Id = p.Id,
                Nombre = p.Nombre,
                Edad = p.FechaNacimiento.GetCurrentAge(), // Calcula la edad aquí
                Telefono = p.Telefono,
                Username = p.Username,
                Password = p.Password,
                // ... otras propiedades ...
            }).ToList();

            return personasDTO.Take(10).ToList();
        }


        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Puedes manejar las excepciones de actualización de la base de datos aquí
                // Por ejemplo, registrar el error o tomar medidas adicionales según tus necesidades.
                throw ex; // Puedes lanzar la excepción nuevamente o manejarla de otra manera.
            }
        }

        public async Task AddPersonaAsync(Personas persona)
        {
            db.Personas.Add(persona);
            await SaveChangesAsync();
        }
















    }
}

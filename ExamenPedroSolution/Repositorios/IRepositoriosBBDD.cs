using DTOs;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public interface IRepositoriosBBDD
    {
        Task<IEnumerable<Personas>> GetPersonasAsync();
        Task<ActionResult<List<PersonasDTO>>> GetPersonasMayoresDe21();

        Task<int> SaveChangesAsync();

        Task AddPersonaAsync(Personas persona);
    }
}

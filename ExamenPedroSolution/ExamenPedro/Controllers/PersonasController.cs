using AutoMapper;
using DTOs;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositorios;

namespace ExamenPedro.Controllers
{

    [Route("api/personas")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IMapper mapper;
        private IConfiguration configuration;
        private IRepositoriosBBDD repodb;

        public PersonasController(IMapper mapper, IConfiguration configuration, IRepositoriosBBDD repodb)
        {
            this.mapper = mapper;
            this.configuration = configuration;
            this.repodb = repodb;
        }


        [HttpGet]
        [HttpHead]

        public async Task<ActionResult<List<PersonasDTO>>> GetPersonas()
        {


            IEnumerable<Personas> personaFromRepo = await repodb.GetPersonasAsync();

            return Ok(mapper.Map<List<PersonasDTO>>(personaFromRepo));
        }

        [HttpGet("mayoresDe21")]
        public async Task<ActionResult<List<PersonasDTO>>> GetPersonasMayoresDe21()
        {
            var personasDTO = await repodb.GetPersonasMayoresDe21();

            // Devuelve solo los 3 primeros elementos de la lista
            return personasDTO;
        }

        [Route("registrarUsuario")]
        [HttpPost]

        public async Task<ActionResult> RegistroUsuario([FromBody] PersonasCrearDTO personasCrearDTO)
        {
            try
            {
                // Mapea el DTO a la entidad Personas utilizando AutoMapper
                var persona = mapper.Map<Personas>(personasCrearDTO);

                // Realiza alguna validación si es necesaria antes de agregar a la base de datos

                // Agrega la entidad a la base de datos de manera asincrónica y espera a que se complete
                await repodb.AddPersonaAsync(persona);

                // Luego, guarda los cambios en la base de datos
                await repodb.SaveChangesAsync();

                // Devuelve una respuesta exitosa
                return Ok("Usuario registrado exitosamente");
            }
            catch (Exception ex)
            {
                // En caso de error, devuelve una respuesta de error
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al registrar el usuario");
            }
        }


    }



}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Personas
    {

        [Key]

        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Nombre { get; set; }

        [Required]
        public DateTime? FechaNacimiento { get; set; }
        [MaxLength(25)]
        public string Telefono { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }


    }
}

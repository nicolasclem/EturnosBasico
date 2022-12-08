﻿using System.ComponentModel.DataAnnotations;

namespace Eturnos.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public string  Email { get; set; }

        public List<Turno> Turno { get; set; }
    }
}

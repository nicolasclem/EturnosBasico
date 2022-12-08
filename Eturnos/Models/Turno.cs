using System.ComponentModel.DataAnnotations;

namespace Eturnos.Models
{
    public class Turno
    {
        [Key]
        public int Id { get; set; }
        public int  IdPaciente { get; set; }
        public int IdMedico { get; set; }

        [Display(Name ="Fecha hora  Inicio")]
        public DateTime FechaHoraInicio { get; set; }
        [Display(Name = "Fecha hora  Fin")]
        public DateTime FechaHoraFin { get; set; }

        public Paciente Paciente { get; set; }

        public Medico Medico { get; set; }

    }
}

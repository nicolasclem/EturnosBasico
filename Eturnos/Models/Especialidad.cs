using System.ComponentModel.DataAnnotations;

namespace Eturnos.Models
{

    public  class Especialidad
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public List<MedicoEspecialidad> MedicoEspecialidad { get; set; }
    }
}

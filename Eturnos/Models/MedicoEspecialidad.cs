namespace Eturnos.Models
{
    public class MedicoEspecialidad
    {
        public int IdMedico { get; set; }

        public int IdEspeciliadad { get; set; }

        public Medico Medico { get; set; }

        public Especialidad Especialidad  { get; set; }

        

    }
}

using Eturnos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eturnos.Controllers
{
    public class TurnoController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IConfiguration configuration;

        public TurnoController(ApplicationDbContext context ,IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            ViewData["IdMedico"] = new SelectList((from medico in context.Medicos.ToList() select new {IdMedico = medico.Id,NombreCompleto= medico.Nombre +" "+ medico.Apellido}),"IdMedico","NombreCompleto");
            ViewData["IdPaciente"] = new SelectList((from paciente in context.Pacientes.ToList() select new { IdPaciente = paciente.Id, NombreCompleto = paciente.Nombre + " " + paciente.Apellido }), "IdMedico", "NombreCompleto");

            return View();
        }
    }
}

using Eturnos.Data;
using Eturnos.Models;
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
        public JsonResult ObtenerTurnos(int idMedico)
        {
            List<Turno> turnos = new List<Turno>();
            turnos = context.Turnos.Where(t => t.IdMedico == idMedico).ToList();
       
            return Json(turnos);
        }
        [HttpPost]
        public JsonResult GrabarTurno(Turno turno)
        {
            var ok = false;
            try
            {
                context.Turnos.Add(turno);
                context.SaveChanges();
                ok = true;
            }
            catch (Exception e)
            {

                Console.WriteLine("{0} excepcion encontrada",e);
            }

            var jsonResult = new {ok = ok};

            return Json(jsonResult);

        }
        [HttpPost]
        public JsonResult EliminarTurno(int idTurno)
        {
            var ok = false;
            try
            {
                var turnoAEliminar = context.Turnos.Where(t => t.Id == idTurno).FirstOrDefault();
                if (turnoAEliminar != null)
                {
                    context.Turnos.Remove(turnoAEliminar);
                    context.SaveChanges() ;
                    ok = true;

                }
            
            }
            catch (Exception e)
            {

                Console.WriteLine("{0} Excepcion encontrada",e);
            }

            var jsonResult = new {ok = ok};
            return Json(jsonResult);
        }
    }
}

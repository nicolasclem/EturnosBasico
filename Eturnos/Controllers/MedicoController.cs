using Eturnos.Data;
using Eturnos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Eturnos.Controllers
{
    public class MedicoController : Controller
    {
        private readonly ApplicationDbContext context;

        public MedicoController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var medico = await context.Medicos.ToListAsync();
            return View(medico);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var medico = await context.Medicos
                .Where(p => p.Id == id)
                .Include(me => me.MedicoEspecialidad)
                .ThenInclude(e => e.Especialidad).FirstOrDefaultAsync();

            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        public IActionResult Create()
        {
            ViewData["ListaEspecialidades"] = new SelectList(context.Especialidades, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Medico medico, int IdEspcialidad)
        {
            if (ModelState.IsValid)
            {
                context.Medicos.Add(medico);
                await context.SaveChangesAsync();

                var medicoEspecialidad= new MedicoEspecialidad();
                medicoEspecialidad.IdMedico = medico.Id;
                medicoEspecialidad.IdEspeciliadad= IdEspcialidad;
                context.Add(medicoEspecialidad);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View(medico);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                NotFound();
            }
            var medico = await context.Medicos.Where(m=>m.Id == id)
                .Include(m=>m.MedicoEspecialidad).FirstOrDefaultAsync();
            if (medico == null)
            {
                return NotFound();
            }
            ViewData["ListaEspecialidades"] = new SelectList(
                context.Especialidades, "Id", "Nombre", medico.MedicoEspecialidad[0].IdEspeciliadad
                );

            return View(medico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] Medico medico,int IdEspe)
        {


            if (ModelState.IsValid)
            {
               
                context.Update(medico);
                await context.SaveChangesAsync();


                var medicoEspecialidad= await  context.MedicosEspecialidades
                    .FirstOrDefaultAsync(m=>m.IdMedico == medico.Id);
                context.Remove(medicoEspecialidad);
                await context.SaveChangesAsync();
                medicoEspecialidad.IdEspeciliadad = IdEspe;
                context.Add(medicoEspecialidad);
                   await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(medico);
        }
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                NotFound();
            }
            var medico = await context.Medicos.FirstOrDefaultAsync(p => p.Id == id);
            if (medico == null)
            {
                return NotFound();
            }
            return View(medico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(Medico medico)
        {

            var medicoEspecialidad= await context.MedicosEspecialidades
                .FirstOrDefaultAsync(me=>me.IdMedico == medico.Id);

            context.MedicosEspecialidades.Remove(medicoEspecialidad);
            await context.SaveChangesAsync();
            var medicoABorrar = await context.Medicos.FindAsync(medico.Id);
            if (medicoABorrar == null)
            {
                return NotFound();
            }
            context.Medicos.Remove(medicoABorrar);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

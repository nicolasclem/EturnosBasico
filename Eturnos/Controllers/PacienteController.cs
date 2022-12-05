using Eturnos.Data;
using Eturnos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eturnos.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ApplicationDbContext context;

        public PacienteController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var paciente = await context.Pacientes.ToListAsync();
            return View(paciente);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var paciente = await context.Pacientes.FirstOrDefaultAsync(p => p.Id == id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                context.Pacientes.Add(paciente);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                NotFound();
            }
            var paciente = await context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] Paciente paciente)
        {
           
            
            if (ModelState.IsValid)
            {
                context.Update(paciente);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(paciente);  
        }

    }
}

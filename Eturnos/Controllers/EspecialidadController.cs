using Eturnos.Data;
using Eturnos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eturnos.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly ApplicationDbContext context;

        public EspecialidadController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {

            var especialidades = await  context.Especialidades.ToListAsync();
            return View(especialidades);
        }

        public async Task<IActionResult> Edit(int? id)
        {
          
            var especialidad = await context.Especialidades.FindAsync(id);

            if(especialidad == null|| id== null) 
            {
                return NotFound();
            }
            
            return View(especialidad);
        }

        [HttpPost]
        
        public async Task<IActionResult> Edit(Especialidad especialidad)
        {
            if(ModelState.IsValid)
            {
                context.Update(especialidad);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
             
            }
            return View(especialidad);
        }

        
        public  async Task<IActionResult> Eliminar(int id)
        {
            var especialidad = await context.Especialidades.FirstOrDefaultAsync(x=>x.Id== id);
            if(especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        [HttpPost]
        
        public async Task<IActionResult> Eliminar(Especialidad especialidad)
        {
            var especialidadAborrar = await context.Especialidades.FindAsync(especialidad.Id);
            if(ModelState.IsValid)
            {
                context.Especialidades.Remove(especialidadAborrar);
                await context.SaveChangesAsync();   
                return RedirectToAction("Index");
            }
            return View(especialidadAborrar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create([Bind("Id","Nombre")] Especialidad especialidad)
        {
            if(ModelState.IsValid) 
            {
                context.Especialidades.Add(especialidad);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(especialidad);
        }
    }
}

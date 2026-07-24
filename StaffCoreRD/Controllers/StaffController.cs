using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffCoreRD.Data;
using StaffCoreRD.Models;

namespace StaffCoreRD.Controllers
{
    [Authorize] // Cualquier usuario logueado (Administrador, RRHH o Viewer) puede entrar al controlador
    public class StaffController : Controller
    {
        private readonly StaffDbContext _context;

        public StaffController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: /Staff  -> Administrador, RRHH y Viewer pueden ver el listado
        public async Task<IActionResult> Index()
        {
            var lista = await _context.Personal
                .Where(s => s.Activo)
                .OrderBy(s => s.Nombre)
                .ToListAsync();
            return View(lista);
        }

        // GET: /Staff/Details/5 -> Administrador, RRHH y Viewer
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var staff = await _context.Personal.FirstOrDefaultAsync(s => s.Id == id);
            if (staff == null) return NotFound();

            return View(staff);
        }

        // GET: /Staff/Create -> Administrador y RRHH
        [Authorize(Roles = "Administrador,RRHH")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Staff/Create -> Administrador y RRHH
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador,RRHH")]
        public async Task<IActionResult> Create(
            [Bind("Nombre,Cedula,Cargo,Departamento,Salario,FechaIngreso,Activo")] Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return View(staff);
            }

            _context.Add(staff);
            await _context.SaveChangesAsync();
            TempData["Exito"] = $"Empleado \"{staff.Nombre}\" creado exitosamente.";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Staff/Edit/5 -> Administrador y RRHH
        [Authorize(Roles = "Administrador,RRHH")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var staff = await _context.Personal.FindAsync(id);
            if (staff == null) return NotFound();

            return View(staff);
        }

        // POST: /Staff/Edit/5 -> Administrador y RRHH
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador,RRHH")]
        public async Task<IActionResult> Edit(
            int id, [Bind("Id,Nombre,Cedula,Cargo,Departamento,Salario,FechaIngreso,Activo")] Staff staff)
        {
            if (id != staff.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(staff);
            }

            try
            {
                _context.Update(staff);
                await _context.SaveChangesAsync();
                TempData["Exito"] = $"Empleado \"{staff.Nombre}\" actualizado exitosamente.";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Personal.AnyAsync(s => s.Id == id))
                    return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Staff/Delete/5 -> Solo Administrador
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var staff = await _context.Personal.FirstOrDefaultAsync(s => s.Id == id);
            if (staff == null) return NotFound();

            return View(staff);
        }

        // POST: /Staff/Delete/5 -> Solo Administrador
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Personal.FindAsync(id);
            if (staff != null)
            {
                _context.Personal.Remove(staff);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
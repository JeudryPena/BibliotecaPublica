using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaPublica.Data;
using BibliotecaPublica.Data.Modelos.Almacen;

namespace BibliotecaPublica.Pages.Admin.Almacen.Inventario
{
    public class EditModel : PageModel
    {
        private readonly BibliotecaPublica.Data.ApplicationDbContext _context;

        public EditModel(BibliotecaPublica.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InventarioModel InventarioModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InventarioModel = await _context.Inventarios
                .Include(i => i.Libro).FirstOrDefaultAsync(m => m.Id == id);

            if (InventarioModel == null)
            {
                return NotFound();
            }
           ViewData["LibroId"] = new SelectList(_context.Libros, "Id", "Titulo");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(InventarioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarioModelExists(InventarioModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InventarioModelExists(int id)
        {
            return _context.Inventarios.Any(e => e.Id == id);
        }
    }
}

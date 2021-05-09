using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BibliotecaPublica.Data;
using BibliotecaPublica.Data.Modelos.Almacen;

namespace BibliotecaPublica.Pages.Admin.Almacen.Inventario
{
    public class DeleteModel : PageModel
    {
        private readonly BibliotecaPublica.Data.ApplicationDbContext _context;

        public DeleteModel(BibliotecaPublica.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InventarioModel = await _context.Inventarios.FindAsync(id);

            if (InventarioModel != null)
            {
                _context.Inventarios.Remove(InventarioModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

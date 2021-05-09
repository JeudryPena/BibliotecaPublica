using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BibliotecaPublica.Data;
using BibliotecaPublica.Data.Modelos.Libros;

namespace BibliotecaPublica.Pages.Admin.Categorias
{
    public class DeleteModel : PageModel
    {
        private readonly BibliotecaPublica.Data.ApplicationDbContext _context;

        public DeleteModel(BibliotecaPublica.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoriaModel CategoriaModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoriaModel = await _context.Categorias.FirstOrDefaultAsync(m => m.Id == id);

            if (CategoriaModel == null)
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

            CategoriaModel = await _context.Categorias.FindAsync(id);

            if (CategoriaModel != null)
            {
                _context.Categorias.Remove(CategoriaModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

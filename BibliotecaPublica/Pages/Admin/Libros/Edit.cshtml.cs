using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaPublica.Data;
using BibliotecaPublica.Data.Modelos.Libros;

namespace BibliotecaPublica.Pages.Admin.Libros
{
    public class EditModel : PageModel
    {
        private readonly BibliotecaPublica.Data.ApplicationDbContext _context;

        public EditModel(BibliotecaPublica.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LibroModel LibroModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LibroModel = await _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.Categoria).FirstOrDefaultAsync(m => m.Id == id);

            if (LibroModel == null)
            {
                return NotFound();
            }
           ViewData["AutorId"] = new SelectList(_context.AutorModel, "Id", "Nombre");
           ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Titulo");
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

            _context.Attach(LibroModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroModelExists(LibroModel.Id))
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

        private bool LibroModelExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
    }
}

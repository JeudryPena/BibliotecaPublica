using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BibliotecaPublica.Data;
using BibliotecaPublica.Data.Modelos.Libros;

namespace BibliotecaPublica.Pages.Admin.Autores
{
    public class DeleteModel : PageModel
    {
        private readonly BibliotecaPublica.Data.ApplicationDbContext _context;

        public DeleteModel(BibliotecaPublica.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AutorModel AutorModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AutorModel = await _context.AutorModel.FirstOrDefaultAsync(m => m.Id == id);

            if (AutorModel == null)
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

            AutorModel = await _context.AutorModel.FindAsync(id);

            if (AutorModel != null)
            {
                _context.AutorModel.Remove(AutorModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

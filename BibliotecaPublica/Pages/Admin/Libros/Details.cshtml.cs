using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BibliotecaPublica.Data;
using BibliotecaPublica.Data.Modelos.Libros;

namespace BibliotecaPublica.Pages.Admin.Libros
{
    public class DetailsModel : PageModel
    {
        private readonly BibliotecaPublica.Data.ApplicationDbContext _context;

        public DetailsModel(BibliotecaPublica.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}

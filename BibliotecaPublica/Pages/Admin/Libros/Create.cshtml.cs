using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BibliotecaPublica.Data;
using BibliotecaPublica.Data.Modelos.Libros;
using Microsoft.AspNetCore.Authorization;

namespace BibliotecaPublica.Pages.Admin.Libros
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly BibliotecaPublica.Data.ApplicationDbContext _context;

        public CreateModel(BibliotecaPublica.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AutorId"] = new SelectList(_context.AutorModel, "Id", "Nombre");
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Titulo");
            return Page();
        }

        [BindProperty]
        public LibroModel LibroModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            LibroModel.GenCodigo();
            _context.Libros.Add(LibroModel);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

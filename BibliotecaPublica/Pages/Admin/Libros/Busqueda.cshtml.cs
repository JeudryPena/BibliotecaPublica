using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BibliotecaPublica.Data;
using BibliotecaPublica.Data.Modelos.Libros;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaPublica.Pages.Admin.Libros
{
    public class BusquedaModel : PageModel
    {
        private readonly BibliotecaPublica.Data.ApplicationDbContext _context;

        public BusquedaModel(BibliotecaPublica.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty, StringLength(128, MinimumLength = 3, ErrorMessage = "Debes escribir un titulo de {1}/{2}: {0}")]
        public string Consulta { get; set; }

        public IList<LibroModel> LibroModel { get;set; }

        public async Task OnGetAsync()
        {
            LibroModel = await _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.Categoria).OrderByDescending(l=>l.Creacion).Take(3).ToListAsync();
        }


        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            LibroModel = await _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.Categoria).Where(L=>L.Codigo.Contains(Consulta) || L.Titulo.Contains(Consulta) || L.Autor.Nombre.StartsWith(Consulta)).ToListAsync();

            return Page();
        }


    }
}

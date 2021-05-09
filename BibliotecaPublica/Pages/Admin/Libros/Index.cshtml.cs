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
    public class IndexModel : PageModel
    {
        private readonly BibliotecaPublica.Data.ApplicationDbContext _context;

        public IndexModel(BibliotecaPublica.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<LibroModel> LibroModel { get;set; }

        public async Task OnGetAsync()
        {
            LibroModel = await _context.Libros
                .Include(l => l.Autor)
                .Include(l => l.Categoria).ToListAsync();
        }
    }
}

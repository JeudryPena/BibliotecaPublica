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
    public class IndexModel : PageModel
    {
        private readonly BibliotecaPublica.Data.ApplicationDbContext _context;

        public IndexModel(BibliotecaPublica.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<InventarioModel> InventarioModel { get;set; }

        public async Task OnGetAsync()
        {
            InventarioModel = await _context.Inventarios
                .Include(i => i.Libro).ToListAsync();
        }
    }
}

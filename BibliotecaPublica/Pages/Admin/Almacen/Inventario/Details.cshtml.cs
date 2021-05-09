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
    public class DetailsModel : PageModel
    {
        private readonly BibliotecaPublica.Data.ApplicationDbContext _context;

        public DetailsModel(BibliotecaPublica.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public InventarioModel InventarioModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InventarioModel = await _context.Inventarios
                .Include(i => i.Libro).Include(i=>i.Usuario).FirstOrDefaultAsync(m => m.Id == id);

            if (InventarioModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

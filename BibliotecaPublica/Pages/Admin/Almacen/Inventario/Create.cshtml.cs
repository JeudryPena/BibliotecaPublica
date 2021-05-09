using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BibliotecaPublica.Data;
using BibliotecaPublica.Data.Modelos.Almacen;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BibliotecaPublica.Pages.Admin.Almacen.Inventario
{
    public class AppFile
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }
    }

    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly BibliotecaPublica.Data.ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> UserManager;

        public CreateModel(BibliotecaPublica.Data.ApplicationDbContext context, UserManager<IdentityUser> _userManager)
        {
            _context = context;
            UserManager = _userManager;
        }

        public IActionResult OnGet()
        {
            ViewData["LibroId"] = new SelectList(_context.Libros, "Id", "Titulo");
            return Page();
        }

        [BindProperty]
        public InventarioModel InventarioModel { get; set; }
        
        [BindProperty]
        public IFormFile IfArchivo{ get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                
                return Page();
            }

            #region Subir archivo
            using (var memoryStream = new MemoryStream())
            {
                await IfArchivo.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    var file = new AppFile()
                    {
                        Content = memoryStream.ToArray()
                    };

                    var UsuarioEnLinea = await UserManager.GetUserAsync(User);
                    InventarioModel.Usuario = UsuarioEnLinea;
                    InventarioModel.Archivo = IfArchivo.FileName;
                    
                    _context.Inventarios.Add(InventarioModel);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("IfArchivo", "The file is too large.");
                }
            }
            #endregion

           

            
           

            return RedirectToPage("./Index");
        }

        public async Task SubirArchivoAsync(FormFile Archivo)
        {
            long size = Archivo.Length;

            if (size > 0)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = System.IO.File.Create(filePath))
                {
                    await Archivo.CopyToAsync(stream);
                }
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.
        }
    }
}

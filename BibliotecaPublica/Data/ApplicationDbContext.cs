using BibliotecaPublica.Data.Modelos.Almacen;
using BibliotecaPublica.Data.Modelos.Libros;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPublica.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<LibroModel> Libros { get; set; }
        public DbSet<AutorModel> AutorModel { get; set; }
        public DbSet<InventarioModel> Inventarios { get; set; }

    }
}

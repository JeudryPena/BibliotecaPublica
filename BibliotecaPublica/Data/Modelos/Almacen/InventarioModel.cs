using BibliotecaPublica.Data.Modelos.Libros;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaPublica.Data.Modelos.Almacen
{
    [Table("Inventarios")]
    public class InventarioModel
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(Libro))]
        public int LibroId { get; set; }

        public LibroModel Libro { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Archivo { get; set; }

        [Display(Name = "Disponible: ")]
        public bool EstaDisponible { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Creado { get; set; }


        [ForeignKey(nameof(Usuario)), ScaffoldColumn(false)]
        public string UsuarioId { get; set; }

        [ScaffoldColumn(false)]
        public IdentityUser Usuario{ get; set; }

        public InventarioModel()
        {
            Creado = DateTime.Now;
        }
    }
}

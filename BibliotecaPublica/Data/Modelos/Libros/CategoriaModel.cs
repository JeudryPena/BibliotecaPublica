using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaPublica.Data.Modelos.Libros
{
    [Table("Categorias")]
    public class CategoriaModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(128), Required]
        public string Titulo { get; set; }

        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }

        public CategoriaModel()
        {
            IsDeleted = false;
        }
    }
}

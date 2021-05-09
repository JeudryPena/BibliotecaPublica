using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaPublica.Data.Modelos.Libros
{
    [Table("Libros")]
    public class LibroModel
    {
        [Key]
        public int Id { get; set; }


        //CodigoLibro: T###Idpublicacion
        //
        [StringLength(32), ScaffoldColumn(false)]
        public string Codigo { get; set; }

        [StringLength(128), Required]
        public string Titulo { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        [Range(0,3000)]
        public int? Publicacion  { get; set; }

        #region Relaciones
        [ForeignKey(nameof(Categoria))]
        public int CategoriaId { get; set; }
        public CategoriaModel Categoria { get; set; }

        [ForeignKey(nameof(Autor))]
        public int AutorId { get; set; }
        public AutorModel Autor { get; set; }
        #endregion



        #region Propiedades ocultas
        [ScaffoldColumn(false)]
        public bool? IsDeleted { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? Creacion { get; set; }
        #endregion

        public LibroModel()
        {
            IsDeleted = false;
            Creacion = DateTime.Now;
        }

        public void GenCodigo()
        {
           Codigo = $"{Titulo.Substring(0, 3).ToUpper()}{DateTime.Now.Ticks.ToString().Substring(0,5)}";
        }
    }
}

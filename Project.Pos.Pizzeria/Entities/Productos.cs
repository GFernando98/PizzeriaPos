using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Pos.Pizzeria.WebApi.Entities
{
    public class Productos
    {
        [Key]       
        public int Id { get; set; }
        [Required]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }

        [MaxLength(500)]
        public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }
    }
}

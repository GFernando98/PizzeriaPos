using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Pos.Pizzeria.WebApi.Entities
{
    public class PedidosDetalle
    {
        [Key]        
        public int Id { get; set; }

        [Required]
        public int PedidoId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

        [Required]
        public decimal Impuesto { get; set; }

        public decimal Total { get; set; }
    }
}

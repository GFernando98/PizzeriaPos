using System.ComponentModel.DataAnnotations;

namespace Project.Pos.Pizzeria.WebApi.DTO
{
    public class PedidosDetalleView
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PedidoId { get; set; }       

        [Required]
        public int ProductoId { get; set; }
        public string Codigo { get; set; }
        public string Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

        [Required]
        public decimal Impuesto { get; set; }

        public decimal Total { get; set; }
    }
}

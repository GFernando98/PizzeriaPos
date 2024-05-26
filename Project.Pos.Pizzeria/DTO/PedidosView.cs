using System.ComponentModel.DataAnnotations;

namespace Project.Pos.Pizzeria.WebApi.DTO
{
    public class PedidosView
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Correlativo { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public string Cliente { get; set; }

        [Required(ErrorMessage = "Debe ingresar la fecha del pedido")]
        public DateTime FechaPedido { get; set; }        
        public decimal TotalPedido { get; set; }
    }
}

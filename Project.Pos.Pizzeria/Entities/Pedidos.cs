using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Pos.Pizzeria.WebApi.Entities
{
    public class Pedidos
    {
        [Key]       
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }
        public string Correlativo { get; set; }

        [Required]
        public DateTime FechaPedido { get; set; }

        [Required]
        public decimal TotalPedido { get; set; }     
    }
}

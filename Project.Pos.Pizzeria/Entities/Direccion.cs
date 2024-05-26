using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Pos.Pizzeria.WebApi.Entities
{
    public class Direccion
    {
        [Key]        
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Calle { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        [MaxLength(150)]
        public string Ciudad { get; set; }

        [Required]
        [MaxLength(70)]
        public string Pais { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes Cliente { get; set; }
    }
}

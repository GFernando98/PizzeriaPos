using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Pos.Pizzeria.WebApi.Entities
{
    public class Direcciones
    {
        [Key]        
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int TipoDireccionId { get; set; }

        [Required(ErrorMessage = "El campo calle es requerido.")]
        [MaxLength(150)]
        public string Calle { get; set; }

        [Required(ErrorMessage = "Debe ingresar el numero de telefono")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "El campo ciudad es requerido.")]
        [MaxLength(150)]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "El campo pais es requerido.")]
        [MaxLength(70)]
        public string Pais { get; set; }
    }
}

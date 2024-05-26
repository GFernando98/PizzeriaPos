using System.ComponentModel.DataAnnotations;

namespace Project.Pos.Pizzeria.WebApi.Entities;

public class Usuarios
{
    [Key()]
    public int Id { get; set; }
    [Required(ErrorMessage = "Debe ingresar el usuario.")]
    [MaxLength(10)]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Debe ingresar una contraseña.")]
    [MaxLength(20)]
    public string Password { get; set; }
}

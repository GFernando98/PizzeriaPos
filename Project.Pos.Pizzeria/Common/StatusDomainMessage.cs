namespace Project.Pos.Pizzeria.WebApi.Common;

public class StatusDomainMessage
{
    public string? GetMessage(StatusDomain status) 
    {
        return status switch
        {
            StatusDomain.UserCreateError => "Ocurrió un error mientras se creaba el usuario.",
            StatusDomain.UserUpdateError => "Ocurrió un error mientras se actualizaba el usuario.",
            StatusDomain.UserDeleteError => "Ocurrió un error mientas se eliminaba el usuario.",
            StatusDomain.UserCreate => "Se creo el usuario correctamente.",
            StatusDomain.UserUpdate => "Se actualizo el usuario correctamente.",
            StatusDomain.UserDelete => "Se eliminado el usuario correctamente.",
            StatusDomain.UserExist => "El usuario ya existe.",
            StatusDomain.UserNotExist => " El usuario no existe.",
            StatusDomain.UserPasswordEquals => "La contraseña no puede ser la misma a la enterior."
        };
    }
}

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
            StatusDomain.UserPasswordEquals => "La contraseña no puede ser la misma a la enterior.",

            StatusDomain.CustomerCreateError => "Ocurrió un error mientras se creaba el cliente.",
            StatusDomain.CustomerUpdateError => "Ocurrió un error mientas se actualizaba el cliente.",
            StatusDomain.CustomerDeleteError => "Ocurrió un error mientras se eliminaba el cliente.",
            StatusDomain.CustomerCreate => "Se creó el cliente correctamente.",
            StatusDomain.CustomerUpdate => "Se actualizo el cliente correctamente.",
            StatusDomain.CustomerDelete => "Se elimino el cliente correctamente.",
            StatusDomain.CustomerExist => "El cliente ya existe.",
            StatusDomain.CustomerNotExist => "El cliente no existe.",

            StatusDomain.AddressExist => "La dirección ya existe.",
            StatusDomain.AddressNotExist => "La dirección no existe.",
            StatusDomain.AddressCreate => "Se creó la direccion correctamente.",
            StatusDomain.AddressCreateError => "Ocurrió un error mientra se creaba la dirección.",
            StatusDomain.AddressUpdate => "Se actualizo la dirección correctamente.",
            StatusDomain.AddressUpdateError => "Ocurrió un error mientras se actualizaba la dirección.",
            StatusDomain.AddressDelete => "Se eliminó la dirección correctamnete.",
            StatusDomain.AddressDeleteError => "Ocurrió un error mientras se eliminaba la dirección",
        };
    }
}

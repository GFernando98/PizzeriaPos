namespace Project.Pos.Pizzeria.WebApi.Common;


public enum StatusDomain
{  
    UserExist,
    UserNotExist,
    UserCreate,
    UserCreateError,
    UserUpdate,
    UserUpdateError,
    UserDelete,
    UserDeleteError,
    UserPasswordEquals,

    CustomerExist,
    CustomerNotExist,
    CustomerCreate,
    CustomerCreateError,
    CustomerUpdate,
    CustomerUpdateError,
    CustomerDelete,
    CustomerDeleteError
}

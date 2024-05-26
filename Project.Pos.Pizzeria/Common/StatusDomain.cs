namespace Project.Pos.Pizzeria.WebApi.Common;


public enum StatusDomain
{  
    Ok,

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
    CustomerDeleteError,

    AddressExist,
    AddressNotExist,
    AddressCreate,
    AddressCreateError,
    AddressUpdate,
    AddressUpdateError,
    AddressDelete,
    AddressDeleteError,

    ProductExist,
    ProductNotExist,
    ProductCreate,
    ProductCreateError,
    ProductUpdate,
    ProductUpdateError,
    ProductDelete,
    ProductDeleteError,

    OrderExist,
    OrderNotExist,
    OrderCreate,
    OrderCreateError,
    OrderUpdate,
    OrderUpdateError,
    OrderDelete,
    OrderDeleteError,
    OrderDetailValidate,

    OrderDetailExist,
    OrderDetailNotExist,
    OrderDetailCreate,
    OrderDetailCreateError,
    OrderDetailUpdate,
    OrderDetailUpdateError,
    OrderDetailDelete,
    OrderDetailDeleteError,
}

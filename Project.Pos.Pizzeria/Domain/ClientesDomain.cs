using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Project.Pos.Pizzeria.WebApi.Common;
using Project.Pos.Pizzeria.WebApi.Entities;
using Project.Pos.Pizzeria.WebApi.Repository;
using System.Security.Cryptography;

namespace Project.Pos.Pizzeria.WebApi.Domain
{
    public class ClientesDomain
    {
        readonly ClientesRepository _clientesRepository;
        public ClientesDomain(ClientesRepository clientesRepository)
        {
            this._clientesRepository = clientesRepository;
        }

        public async Task<StatusDomain> CreateCustomer(Clientes entity)
        {
            var getCustomer = await _clientesRepository.GetCustomersById(entity);
            if (getCustomer != null) return StatusDomain.CustomerExist;         
            var insert = await _clientesRepository.InsertCustomers(entity);
            return insert == 0 ? StatusDomain.CustomerCreateError : StatusDomain.CustomerCreate;
        }

        public async Task<StatusDomain> UpdateCustomer(Clientes entity)
        {
            var getCustomer = await _clientesRepository.GetCustomersById(entity);
            if (getCustomer == null) return StatusDomain.CustomerNotExist;           
            var update = await _clientesRepository.UpdateCustomers(entity);
            return update == 0 ? StatusDomain.CustomerUpdateError : StatusDomain.CustomerUpdate;
        }

        public async Task<StatusDomain> DeleteCustomer(Clientes entity)
        {
            var getCustomer = await _clientesRepository.GetCustomersById(entity);
            if (getCustomer == null) return StatusDomain.UserNotExist;
            var delete = await _clientesRepository.DeleteCustomers(getCustomer);
            return delete == 0 ? StatusDomain.CustomerDeleteError : StatusDomain.CustomerDelete;
        }
    }
}

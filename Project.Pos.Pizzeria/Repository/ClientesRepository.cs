using PosPizzeria.Framework.GenericRepository.GenericRepository;
using Project.Pos.Pizzeria.WebApi.Entities;

namespace Project.Pos.Pizzeria.WebApi.Repository
{
    public class ClientesRepository
    {
        private readonly IRepository<SqlServerRepository> _repository;

        public ClientesRepository(IRepository<SqlServerRepository> repository)
        {
            _repository = repository;
        }

        public async Task<int> InsertCustomers(Clientes entity)
        {
            var insert = await _repository.Insert(entity);
            return insert;
        }

        public async Task<int> UpdateCustomers(Clientes entity)
        {
            var update = await _repository.Update(entity, entity.Id);
            return update;
        }

        public async Task<int> DeleteCustomers(Clientes entity)
        {
            var delete = await _repository.Delete<Clientes>(entity.Id);
            return delete;
        }

        public async Task<Clientes> GetCustomersById(Clientes entity)
        {
            var getCustomer = await _repository.Find<Clientes>(("Id", entity.Id));
            return getCustomer;
        }

    }
}

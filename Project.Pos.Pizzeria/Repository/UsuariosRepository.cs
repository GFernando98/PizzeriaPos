using PosPizzeria.Framework.GenericRepository.GenericRepository;
using Project.Pos.Pizzeria.WebApi.Entities;

namespace Project.Pos.Pizzeria.WebApi.Repository
{
    public class UsuariosRepository
    {
        private readonly IRepository<SqlServerRepository> _repository;

        public UsuariosRepository(IRepository<SqlServerRepository> repository)
        {
            _repository = repository;
        }

        public async Task<int> InsertUser(Usuarios entity)
        {
            var insert = await _repository.Insert(entity);
            return insert;
        }

        public async Task<int> UpdateUser(Usuarios entity) 
        {
            var update = await _repository.Update(entity, entity.Id);
            return update;
        }


        public async Task<Usuarios> GetUserByUserName(Usuarios entity) 
        { 
            var getUser = await _repository.Find<Usuarios>(("UserName", entity.UserName));
            return getUser;
        }

    }
}

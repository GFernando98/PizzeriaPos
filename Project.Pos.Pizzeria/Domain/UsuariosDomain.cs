using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Project.Pos.Pizzeria.WebApi.Common;
using Project.Pos.Pizzeria.WebApi.Entities;
using Project.Pos.Pizzeria.WebApi.Repository;
using System.Security.Cryptography;

namespace Project.Pos.Pizzeria.WebApi.Domain
{
    public class UsuariosDomain
    {
        readonly UsuariosRepository _usuariosRepository;

        public UsuariosDomain(UsuariosRepository repository)
        {
            this._usuariosRepository = repository;
        }

        public async Task<StatusDomain> CreateUser(Usuarios entity)
        {
            var getUser = await _usuariosRepository.GetUserByUserName(entity);
            if (getUser != null) return StatusDomain.UserExist;

            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: entity.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
                ));

            entity.Password = hashedPassword;

            var insert = await _usuariosRepository.InsertUser(entity);
            return insert == 0 ? StatusDomain.UserCreateError : StatusDomain.UserCreate;
        }


        public async Task<StatusDomain> UpdateUser(Usuarios entity)
        {
            var getUser = await _usuariosRepository.GetUserByUserName(entity);
            if(getUser == null) return StatusDomain.UserNotExist;

            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: entity.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
                ));

            if (hashedPassword == getUser.Password) return StatusDomain.UserPasswordEquals;

            getUser.Password = hashedPassword;
            
            var update = await _usuariosRepository.UpdateUser(getUser);
            return update == 0 ? StatusDomain.UserUpdateError : StatusDomain.UserUpdate;
        }
    }
}

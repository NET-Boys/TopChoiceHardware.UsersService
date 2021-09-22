using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChoiceHardware.UsersService.Domain.Commands;
using TopChoiceHardware.UsersService.Domain.DTOs;
using TopChoiceHardware.UsersService.Domain.Entities;

namespace TopChoiceHardware.UsersService.Application.Services
{
    public interface IUsuarioService
    {
        Usuario CreateUsuario(UsuarioDto usuario);
        List<Usuario> GetUsuarios();
        Usuario GetUsuarioById(int id);
    }
    public class UsuarioService : IUsuarioService
    {
        private IGenericRepository _repository;

        public UsuarioService(IGenericRepository repository)
        {
            _repository = repository;
        }

        public Usuario CreateUsuario(UsuarioDto usuario)
        {
            var entity = new Usuario
            {
                Name = usuario.Name,
                Username = usuario.Username,
                DNI = usuario.DNI,
                AddressId = usuario.AddressId,
                Email = usuario.Email,
                Password = usuario.Password,
                RoleId = usuario.RoleId
            };

            _repository.Add(entity);
            return entity;
        }

        public List<Usuario> GetUsuarios()
        {
            return _repository.GetAll<Usuario>();
        }

        public Usuario GetUsuarioById(int id)
        {
            return _repository.GetById<Usuario>(id);
        }
    }
}

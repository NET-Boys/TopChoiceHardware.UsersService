using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChoiceHardware.UsersService.Application.Validations;
using TopChoiceHardware.UsersService.Domain.Commands;
using TopChoiceHardware.UsersService.Domain.DTOs;
using TopChoiceHardware.UsersService.Domain.Entities;

namespace TopChoiceHardware.UsersService.Application.Services
{
    public interface IUsuarioService
    {
        Usuario CreateUsuario(UsuarioDtoForCreation usuario);
        List<Usuario> GetUsuarios();
        Usuario GetUsuarioById(int id);

        Usuario GetUsuarioByEmailAndPassword(string email, string password);

        void UpdateUsuario(Usuario usuario);
    }
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioValidations _validations;

        public UsuarioService(IUsuarioRepository repository, IUsuarioValidations validations)
        {
            _repository = repository;
            _validations = validations;
        }

        public Usuario CreateUsuario(UsuarioDtoForCreation usuario)
        {
            var entity = new Usuario
            {
                Name = usuario.Name,
                Username = usuario.Username,
                DNI = usuario.DNI,
                Email = usuario.Email,
                Password = usuario.Password,
                RoleId = 2
            };

            if(_validations.DniInDb(entity.DNI) && _validations.EmailInDB(entity.Email)) 
            {
                _repository.Add(entity);
                return entity;
            }

            return null;
        }

        public List<Usuario> GetUsuarios()
        {
            return _repository.GetAllUsuarios();
        }

        public Usuario GetUsuarioById(int id)
        {
            return _repository.GetUsuarioById(id);
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _repository.Update(usuario);
        }

        public Usuario GetUsuarioByEmailAndPassword(string email, string password)
        {
            return _repository.GetUsuarioByEmailAndPassword(email, password);
        }
    }
}

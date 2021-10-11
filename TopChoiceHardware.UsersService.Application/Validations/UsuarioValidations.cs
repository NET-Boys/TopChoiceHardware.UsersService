using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChoiceHardware.UsersService.Domain.Commands;
using TopChoiceHardware.UsersService.Domain.Entities;

namespace TopChoiceHardware.UsersService.Application.Validations
{
    public interface IUsuarioValidations
    {
        bool EmailInDB(string email);
        bool DniInDb(string dni);
    }
    
    public class UsuarioValidations : IUsuarioValidations
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioValidations(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public bool DniInDb(string dni)
        {
            return _repository.GetUsuarioByDni(dni) == null;
        }

        public bool EmailInDB(string email)
        {
            return _repository.GetUsuarioByEmail(email) == null;
        }
    }
}

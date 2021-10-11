using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChoiceHardware.UsersService.Domain.Entities;

namespace TopChoiceHardware.UsersService.Domain.Commands
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);
        List<Usuario> GetAllUsuarios();
        void Update(Usuario usuario);
        void Delete(Usuario usuario);
        void DeleteById(int id);
        Usuario GetUsuarioById(int id);
        Usuario GetUsuarioByEmail(string email);
        Usuario GetUsuarioByDni(string dni);
    }
}

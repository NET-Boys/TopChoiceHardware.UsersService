using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChoiceHardware.UsersService.Domain.Commands;
using TopChoiceHardware.UsersService.Domain.Entities;

namespace TopChoiceHardware.UsersService.AccessData.Commands
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuariosContext _context;
        
        public UsuarioRepository(UsuariosContext context)
        {
            _context = context;
        }
        
        public void Add(Usuario usuario)
        {

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Delete(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var usuario = GetUsuarioById(id);
            Delete(usuario);
        }

        public List<Usuario> GetAllUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetUsuarioByDni(string dni)
        {
            return _context.Usuarios.SingleOrDefault(Usuario => Usuario.DNI == dni);
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            return _context.Usuarios.SingleOrDefault(Usuario => Usuario.Email == email);
        }

        public Usuario GetUsuarioById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Update(Usuario usuario)
        {
            _context.Update(usuario);
            _context.SaveChanges();
        }
    }
}

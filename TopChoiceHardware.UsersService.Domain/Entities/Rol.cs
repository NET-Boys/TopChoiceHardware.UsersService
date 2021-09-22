using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.UsersService.Domain.Entities
{
    public class Rol
    {
        public Rol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}

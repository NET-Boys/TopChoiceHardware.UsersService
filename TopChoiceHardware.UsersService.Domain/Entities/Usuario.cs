using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.UsersService.Domain.Entities
{
    public class Usuario
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int AddressId { get; set; }
        public int RoleId { get; set; }

        public Rol Role { get; set; }
    }
}

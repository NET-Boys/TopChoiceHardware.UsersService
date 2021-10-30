using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChoiceHardware.UsersService.Domain.Entities;

namespace TopChoiceHardware.UsersService.Domain.DTOs
{
    public class SuccesfulRegisterDto
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }

        public SuccesfulRegisterDto(Usuario usuario)
        {
            Message = "You have signed up succesfully";
            Status = "Success";
            UserId = usuario.UserId;
        }
    }
}

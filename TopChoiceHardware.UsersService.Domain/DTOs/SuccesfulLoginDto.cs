using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.UsersService.Domain.DTOs
{
    public class SuccesfulLoginDto
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public string Token { get; set; }

        public SuccesfulLoginDto(string token)
        {
            Message = "You have logged in succesfully";
            Status = "Success";
            Token = token;
        }
    }
}

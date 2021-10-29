using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.UsersService.Domain.DTOs
{
    public class UnsuccesfulRegisterDto
    {
        public string Message { get; set; }
        public string Status { get; set; }

        public UnsuccesfulRegisterDto()
        {
            Message = "An error occurred when you tried to sign up. The email or ID is already in use.";
            Status = "Error";
        }
    }
}

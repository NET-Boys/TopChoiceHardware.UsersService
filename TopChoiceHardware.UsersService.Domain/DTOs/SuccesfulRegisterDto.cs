using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.UsersService.Domain.DTOs
{
    public class SuccesfulRegisterDto
    {
        public string Message { get; set; }
        public string Status { get; set; }

        public SuccesfulRegisterDto()
        {
            Message = "You have signed up succesfully";
            Status = "Success";
        }
    }
}

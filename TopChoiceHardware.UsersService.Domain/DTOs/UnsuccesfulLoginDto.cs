using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.UsersService.Domain.DTOs
{
    public class UnsuccesfulLoginDto
    {
        public string Message { get; set; }
        public string Status { get; set; }

        public UnsuccesfulLoginDto()
        {
            Message = "There was a problem when you logged in. Please try again";
            Status = "Error";
        }
    }
}

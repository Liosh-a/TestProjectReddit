using System;
using System.Collections.Generic;
using System.Text;

namespace TPR.Dto.DtoModels
{
    public class RegistrationDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

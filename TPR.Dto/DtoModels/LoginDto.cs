using System;
using System.Collections.Generic;
using System.Text;

namespace TPR.Dto.DtoModels
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }
}

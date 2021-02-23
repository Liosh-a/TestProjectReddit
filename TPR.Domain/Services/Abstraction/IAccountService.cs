using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TPR.Dto.DtoResult;
using TPR.Dto.DtoModels;


namespace TPR.Domain.Services.Abstraction
{
    public interface IAccountService
    {
        Task<ResultDto> Register(RegistrationDto entity);
        Task<ResultDto> Login(LoginDto entity);
    }
}

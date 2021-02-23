using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPR.Domain.Services.Abstraction;
using TPR.Dto.DtoResult;
using TPR.Dto.DtoModels;

namespace TestProjectReddit.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<ResultDto> Register([FromBody] RegistrationDto model)
        {
            try
            {
                return await _accountService.Register(model);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPost]
        public async Task<ResultDto> Login([FromBody] LoginDto model)
        {
            try
            {
                return await _accountService.Login(model);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

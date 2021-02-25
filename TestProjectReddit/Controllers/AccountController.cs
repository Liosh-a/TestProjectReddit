using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPR.Domain.Services.Abstraction;
using TPR.Dto.DtoResult;
using TPR.Dto.DtoModels;
using RestSharp;

namespace TestProjectReddit.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
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
        [HttpPost("accesstoken")]
        public async Task<IActionResult> accesstoken(testdto code)
        {
            var client = new RestClient("https://www.reddit.com/api/v1/access_token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic ZkFGNUdIVlgtclZxX2c6eFNmMG1ocVgwSXdGTHJCTkpmWHB1YTh5SVJyMmh3");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", "edgebucket=3CpZJ6Zi890x60cSbH");
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("code", code.code);
            request.AddParameter("redirect_uri", "https://localhost:44395");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return Ok(response);
        }
    }
}

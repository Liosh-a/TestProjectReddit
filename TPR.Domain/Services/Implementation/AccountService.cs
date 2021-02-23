using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TPR.DataAccess.Entities;
using TPR.Domain.Services.Abstraction;
using TPR.Dto.DtoResult;
using TPR.Dto.DtoModels;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace TPR.Domain.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public AccountService(UserManager<User> userManager,
                                 SignInManager<User> signInManager,
                                 IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<ResultDto> Register(RegistrationDto entity)
        {
            var user = new User
            {
                Email = entity.Email,
                UserName = entity.Email
            };
            var result = await _userManager.CreateAsync(user, entity.Password);

                return await Login(new LoginDto { Email = entity.Email, IsRemember = false, Password = entity.Password });
        }

        public async Task<ResultDto> Login(LoginDto entity)
        {
            var result = await _signInManager.PasswordSignInAsync(entity.Email, entity.Password, entity.IsRemember, false);

                var user = _userManager.Users.SingleOrDefault(r => r.Email == entity.Email);
                var token = await GenerateJwtToken(entity.Email, user);
                return new SingleResultDto<string> { Data = token.ToString(), IsSuccessful = true };
        }

        private async Task<object> GenerateJwtToken(string email, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

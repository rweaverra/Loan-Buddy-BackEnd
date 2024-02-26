using AutoMapper;
using Loan_Buddy_Api.Data;
using Loan_Buddy_Api.DTOs;
using Loan_Buddy_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Loan_Buddy_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDBContext _db;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthController(AppDBContext context, IConfiguration configuration, IMapper mapper)
        {
            _db = context;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult> Login(string username, string password)
        {
            Dictionary<string, object> results = new();

            var user = await _db.Users.Where(u => u.Email == username).FirstOrDefaultAsync();

            if (user is null)
                return BadRequest("no user found");

            if (user.Password != password)
                return BadRequest("password doesn't match");
            else
            {
                var token = CreateToken(user);
                results.Add("token", token);

                var mappedUser = _mapper.Map<UserDto>(user);
                results.Add("user", mappedUser);
                return Ok(results);
            }
        }


        [HttpPost]
        public async Task<ActionResult<int>> Register(User user, string password)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return Ok(user.UserId);
        }


        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


        //public async Task<ActionResult<string>> Login(string userName, string password)
        //{
        //    var result = await _authRepo.Login(userName, password);

        //    if (result == "success")
        //        return Ok("success");
        //    else
        //        return BadRequest(result);



        //}
    }
}

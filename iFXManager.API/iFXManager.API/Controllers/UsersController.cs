using iFXManager.DAL.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace iFXManager.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UsersController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager,IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationResponseDto>> Register(CredentialsUsersDto credentialsUsersDto)
        {
            if (credentialsUsersDto == null)
            {
                return BadRequest();
            }

            var user = new IdentityUser
            {
                Email = credentialsUsersDto.Email,
                UserName = credentialsUsersDto.UserName
            };

            var result = await _userManager.CreateAsync(user, credentialsUsersDto.Password!);

            if (result.Succeeded)
            {
                return await BuildToken(user);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponseDto>> Login(CredentialsUsersDto credentialsUsersDto)
        {
            var user = await _userManager.FindByEmailAsync(credentialsUsersDto.Email!);

            if (user == null)
            {
                return BadRequest();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, credentialsUsersDto.Password!, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return await BuildToken(user);
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<AuthenticationResponseDto> BuildToken(IdentityUser identityUser)
        {
            var claims = new List<Claim>
            {
                new Claim("email", identityUser.Email!),
                new Claim("userName", identityUser.UserName!)
            };

            var claimsDB = await _userManager.GetClaimsAsync(identityUser);

            claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["secretKeyIFx"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(5);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims,expires:expiration, signingCredentials: credentials);
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return new AuthenticationResponseDto
            {
                Token = token,
                Expiration = expiration,
            };
        }
    }
}

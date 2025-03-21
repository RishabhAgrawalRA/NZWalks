using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        //POST /api/Auth/register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            //Create Identity User for creating actual user below
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.UserName
            };

            //creating user and storing result in 
            var identityResult =  await userManager.CreateAsync(identityUser, registerRequestDTO.Password);

            if (identityResult.Succeeded)
            {
                //Add Roles to the User
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);

                    if(identityResult.Succeeded)
                        return Ok();
                }

            }

            return BadRequest("Something didn't work");
        }

        //POST /api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            //Find User
            var user = await userManager.FindByEmailAsync(loginRequestDTO.UserName);

            if (user != null) 
            {
                //Check Password
                var checkPassResult = await userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

                if (checkPassResult)
                {
                    //Get Roles
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null) 
                    {
                        //Create Token
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDTO { JWTToken = jwtToken };
                        return Ok(response);
                    }
                }
            }
            
            return BadRequest("Username/Password not correct");
        }
    }
}

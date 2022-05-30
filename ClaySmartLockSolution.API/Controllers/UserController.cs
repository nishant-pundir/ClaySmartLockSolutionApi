using ClaySmartLockSolution.Application.Commands;
using ClaySmartLockSolution.Application.Queries;
using ClaySmartLockSolution.Application.Responses;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClaySmartLockSolution.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public UserController(IMediator mediator, IConfiguration Configuration)
        {
            _mediator = mediator;
            _configuration = Configuration;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<UserResponse>> Get()
        {
            return await _mediator.Send(new GetAllUserQuery());
        }

        [AllowAnonymous]

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserResponse>> Create([FromBody] CreateUserCommand command)
        {
       
            var result = await _mediator.Send(command);
            if (result != null)
                return Ok(result);

            return BadRequest("User Exists Already");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserResponse>> Login([FromBody] Core.Dto.LoginModel userLogin)
        {
            var result = await _mediator.Send(new AuthenticateUserQuery{ user= userLogin });

            if (result != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                  {
                     new Claim(ClaimTypes.Name, result.Email)
                  }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(new Tokens { Token = tokenHandler.WriteToken(token) });
            }
            
          return Unauthorized();
        }


        [Authorize]
        [Route("opendoor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserResponse>> Open([FromBody] Core.Dto.DoorAccessModel doorAccessModel)
        {
            var userResponse = await _mediator.Send(new GetUserByIdQuery { Id = doorAccessModel.UserId });

            if (userResponse != null&& userResponse.DoorAccessTag==doorAccessModel.DoorAccessTag)
            {
                CreateDoorAccessCommand command = new CreateDoorAccessCommand 
                                                { UserId = doorAccessModel.UserId,
                                                  DoorId=doorAccessModel.DoorId,
                                                  AccessAtemptSuccess=true
                                                };
               var userDoorAccessResponse= await _mediator.Send(command);


               return Ok(userDoorAccessResponse);
            };

            return Unauthorized();
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetUserByIdQuery { Id = id }));
        }
    }
}

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using MessagingApi.Entities;
using MessagingApi.Helpers;
using MessagingApi.Models;
using MessagingApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MessagingApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly ILogger<UsersController> _logger;
        private ITokenService _tokenService;
        private IBlockService _blockService;
        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            ILogger<UsersController> logger,
            ITokenService tokenService,
            IBlockService blockService)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _logger = logger;
            _tokenService = tokenService;
            _blockService = blockService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
            {
                _logger.LogError($"User not found {0}",model.Username);
                return BadRequest(new { message = "Username or password is incorrect" });
            }
                

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            _logger.LogInformation($"User found {0}", model.Username);
            var tokenModel = new TokenModel(tokenString, user.Id);
            var tokenModelMapped = _mapper.Map<Token>(tokenModel);
            _tokenService.Save(tokenModelMapped);
            // return basic user info and authentication token
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            // map model to entity
            var user = _mapper.Map<User>(model);

            try
            {
                // create user
                _userService.Create(user, model.Password);
                _logger.LogInformation($"Trying to find User: {0}", model.Username);
                return Ok();
            }
            catch (AppException ex)
            {
                _logger.LogError($"Could not register User {0}", model.Username);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var model = _mapper.Map<IList<UserModel>>(users);
            _logger.LogInformation("Get all users");
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            var model = _mapper.Map<UserModel>(user);
            _logger.LogInformation($"Found User: {0}", model.Username);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateModel model)
        {
            // map model to entity and set id
            var user = _mapper.Map<User>(model);

            user.Id = id;

            try
            {
                // update user 
                _logger.LogInformation($"Updating User: {0}", model.Username);
                _userService.Update(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                _logger.LogError($"Could not update User: {0}", model.Username);
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            _logger.LogInformation($"Deleting User with Id : {0}",id);
            return Ok();
        }

        [HttpPost("block")]
        public IActionResult Block([FromBody] BlockModel blockModel)
        {
            if(blockModel != null)
            {
                if (!string.IsNullOrEmpty(blockModel.blockFromUsername) && string.IsNullOrEmpty(blockModel.blockToUsername))
                {
                    var blockFrom = _userService.FindByUserName(blockModel.blockFromUsername);
                    var blockTo = _userService.FindByUserName(blockModel.blockToUsername);

                    if(blockFrom!=null && blockTo != null)
                    {
                        _blockService.Block(blockFrom.Id, blockTo.Id, blockModel.isBlocked);
                        return Ok(new
                        {
                            blockFrom = blockFrom.Username,
                            blockTo = blockTo.Username,
                            blockModel.isBlocked
                        });
                    }
                    else
                    {
                        _logger.LogError("Blocking person could not be found.");
                        return BadRequest("Blocking person could not be found.");
                    }
                }
                else
                {
                    _logger.LogError("Credentials are not sufficient.");
                    return BadRequest("Credentials are not sufficient.");
                }
            }
            _logger.LogError("Credentials needed.");
            return BadRequest("Credentials needed.");
        }
    }
}

using System;
using AcmeCorporation.API.Data.Contracts;
using AcmeCorporation.API.Data.Models;
using AcmeCorporation.API.Dto;
using AcmeCorporation.API.Services;
using AcmeCorporation.API.Shared.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcmeCorporation.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IAuthService authService, IMapper mapper)
        {
            _userRepository = userRepository;
            _authService = authService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserDto userDto)
        {
            // throw new Exception("computer says no");
            var user = _authService.Authenticate(userDto.EmailAddress, userDto.Password);

            if (user == null)
                return Unauthorized(new { message = "Username or password is incorrect" });

            return Ok(new
            {
                token = user.Token
            });
        }
        [HttpGet]
        [AllowAnonymous]

        public bool validateEmailExist(string email)
        {
            return _userRepository.UserExist(email);
        }

        // [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<UserDto> Register([FromBody] UserDto userDto)
        {
            if (userDto.EmailAddress == null || userDto.Password == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            userDto.Role = Role.User;

            var user = _authService.Register(_mapper.Map<UserDto, User>(userDto), userDto.Password);

            return Ok(_mapper.Map<User, UserDto>(user));
        }
    }
}
using Azure.Identity;
using BookShop.Application.Contracts;
using BookShop.Application.Dto.Authentication;
using BookShop.Application.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("api/[Controller]")]
public class AccountController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;
    public AccountController(ITokenService tokenService,IUserService userService)
    {
        _tokenService = tokenService;
        _userService = userService;
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var result = await _userService.LoginAsync(dto);
        switch (result)
        {
            case LoginDto.LoginResult.Success:
                var user = await _userService.GetByUserNameAsync(dto.Name);
                return new JsonResult(new UserDto()
                {
                    Name = user.Name,
                    Address = user.Profile.Address,
                    NationalId = user.Profile.NationalId,
                    Token = _tokenService.CreateToken(user)
                });
            case LoginDto.LoginResult.Error:
                return Unauthorized();
            case LoginDto.LoginResult.UserNotFound:
                return Unauthorized();
        }

        return Ok();
    }


    [AllowAnonymous]
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var result = await _userService.RegisterAsync(dto);

        switch (result)
        {
            case RegisterDto.RegisterResult.Success:
                var user = await _userService.GetByUserNameAsync(dto.Name);
                return new JsonResult(new UserDto()
                {
                    Name = user.Name,
                    Address = user.Profile.Address,
                    NationalId = user.Profile.NationalId,
                    Token = _tokenService.CreateToken(user)
                });
            case RegisterDto.RegisterResult.Error:
                return BadRequest("Operation faild.");
            case RegisterDto.RegisterResult.DupplicateUser:
                return BadRequest("User allready exist.");
        }

        return Ok();
    }
    
    
}
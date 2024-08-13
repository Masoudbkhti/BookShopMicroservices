using BookShop.Application.Contracts;
using BookShop.Application.Dto.Authentication;
using BookShop.Application.Dto.Profile;
using BookShop.Application.Services;
using BookShop.Application.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("api/[Controller]")]
public class AccountController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IProfileService _profileService;

    public AccountController(IProfileService profileService, IUserService userService)
    {
        _userService = userService;
        _profileService = profileService;
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var result = await _userService.LoginAsync(dto);
        return new JsonResult(result);
    }


    [AllowAnonymous]
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var result = await _userService.RegisterAsync(dto);
        return new JsonResult(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto dto)
    {
        await _profileService.Update(dto);
        return Ok();
    }

    [HttpDelete("Delete/{userId}")]
    public async Task<IActionResult> DeleteAddress([FromRoute] int userId)
    {
        await _profileService.Delete(userId);
        return Ok();
    }

}
using BuildingManagement.Model.Models.Admin;
using BuildingManagement.Model.Models.Token;
using BuildingManagement.Service.Service.TokenServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagement.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public class TokenController(IdentityService identityService, TokenService tokenService) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> CreateToken(TokenCreateRequestDto request)
    {
        var response = await tokenService.Create(request);
        if (response.AnyError)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AssignRoleToUser(RoleCreateRequestDto request)
    {
        var response = await identityService.CreateRole(request);
        if (response.AnyError)
        {
            return BadRequest(response);
        }

        return Created("", response);
    }
}


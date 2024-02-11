using BuildingManagement.Model.Models.Admin;
using BuildingManagement.Model.Models.Token;
using BuildingManagement.Service.Service.TokenServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingManagement.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
[Authorize]
public class TokenController(IdentityService identityService, TokenService tokenService) : ControllerBase
{
    /// <summary>
    /// Admin Token Alma İşlemi
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> AdminCreateToken(AdminTokenCreateRequestDto request)
    {
        var response = await tokenService.Create(request, null);
        if (response.AnyError)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    /// <summary>
    /// Kullanıcı Token Alma İşlemi
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> UserCreateToken(UserTokenCreateRequestDto request)
    {
        var response = await tokenService.Create(null, request);
        if (response.AnyError)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }


    /// <summary>
    /// Oluşturulan Kullanıcılara Rol Atamaları Gerçekleştirilir.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpPost]
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


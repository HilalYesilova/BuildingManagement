using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Model.Models.Token;
using BuildingManagement.Service.Service.TokenServices.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace BuildingManagement.Service.Service.TokenServices.Services;

public class TokenService(IConfiguration configuration, ITokenRepository tokenRepository) : ITokenService
{
    public async Task<ResponseDto<TokenCreateResponseDto>> Create(TokenCreateRequestDto request)
    {

        var hasUser = await tokenRepository.FindUserAsync(request.TcNo,request.PhoneNumber);

        if (hasUser is null)
        {
            return ResponseDto<TokenCreateResponseDto>.Fail("Username or password is wrong");
        }

        //var checkPassword = await tokenRepository.CheckPasswordAsync(hasUser!, request.Password);

        //if (checkPassword == false)
        //{
        //    return ResponseDto<TokenCreateResponseDto>.Fail("Username or password is wrong");
        //}

        var signatureKey = configuration.GetSection("TokenOptions")["SignatureKey"]!;
        var tokenExpireAsHour = configuration.GetSection("TokenOptions")["Expire"]!;
        var issuer = configuration.GetSection("TokenOptions")["Issuer"]!;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signatureKey));

        SigningCredentials signingCredentials =
            new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var claimList = new List<Claim>();

        var userIdAsClaim = new Claim(ClaimTypes.NameIdentifier, hasUser.Id.ToString());
        var userNameAsClaim = new Claim(ClaimTypes.Name, hasUser.UserName!);
        var idAsClaim = new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString());


        var userClaims = await tokenRepository.GetClaimsAsync(hasUser);

        foreach (var claim in userClaims)
        {
            claimList.Add(new Claim(claim.Type, claim.Value));
        }


        claimList.Add(userIdAsClaim);
        claimList.Add(userNameAsClaim);
        claimList.Add(idAsClaim);

        foreach (var role in await tokenRepository.GetRolesAsync(hasUser))
        {
            claimList.Add(new Claim(ClaimTypes.Role, role));
        }

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddDays(Convert.ToDouble(tokenExpireAsHour)),
            signingCredentials: signingCredentials,
            claims: claimList,
            issuer: issuer
        );

        var responseDto = new TokenCreateResponseDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
        };

        return ResponseDto<TokenCreateResponseDto>.Success(responseDto);
    }
}

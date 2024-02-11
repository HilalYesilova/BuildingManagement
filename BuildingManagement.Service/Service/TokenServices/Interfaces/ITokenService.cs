using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Model.Models.Token;

namespace BuildingManagement.Service.Service.TokenServices.Interfaces;
public interface ITokenService
{
    Task<ResponseDto<TokenCreateResponseDto>> Create(AdminTokenCreateRequestDto? Adminrequest, UserTokenCreateRequestDto? userRequest);
}

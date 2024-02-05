using BuildingManagement.Model.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingManagement.Model.Models.Token;

namespace BuildingManagement.Service.Service.TokenServices.Interfaces
{
    public interface ITokenService
    {
        Task<ResponseDto<TokenCreateResponseDto>> Create(TokenCreateRequestDto request);
    }
}

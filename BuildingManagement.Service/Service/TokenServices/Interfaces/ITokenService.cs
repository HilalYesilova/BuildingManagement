using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Service.Service.TokenServices.Interfaces
{
    public interface ITokenService
    {
        Task<ResponseDto<TokenCreateResponseDto>> Create(TokenCreateRequestDto request);
    }
}

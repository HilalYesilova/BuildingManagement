using BuildingManagement.Model.Models.Admin;
using BuildingManagement.Model.Models.Shared;

namespace BuildingManagement.Service.Service.DuesServices;
public interface IDuesService
{
    Task<ResponseDto<string>> AssignDuesAsync(List<AssignDuesRequestDto> model);
}

using BuildingManagement.Entity;
using BuildingManagement.Model.Models.Admin;
using BuildingManagement.Model.Models.Shared;

namespace BuildingManagement.Service.Service.ApartmentServices;
public interface IApartmentService
{
    Task<ResponseDto<int>> AddApartmentToBuilding(ApartmentCreateRequestDto apartmentCreateRequest);
    Task<ResponseDto<string>> AddUserToApartment(int apartmentId, User user);
    Task<ResponseDto<int?>> GetApartmentUserIdAsync(int apartmentId);
}

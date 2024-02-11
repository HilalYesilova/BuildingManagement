using BuildingManagement.Entity;
using BuildingManagement.Entity.Entities;
using BuildingManagement.Model.Models.Admin;
using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Repository;
using BuildingManagement.Repository.Repository.ApartmentRepository;

namespace BuildingManagement.Service.Service.ApartmentServices;
public class ApartmentService(IApartmentRepository apartmentRepository, IUnitOfWork unitOfWork) : IApartmentService
{
    public async Task<ResponseDto<int>> AddApartmentToBuilding(ApartmentCreateRequestDto apartmentCreateRequest)
    {
        var building = await apartmentRepository.GetBuildingInfo();

        var apartment = new Apartment
        {
            BlockInfo = apartmentCreateRequest.BlockInfo,
            OccupancyStatus = apartmentCreateRequest.OccupancyStatus,
            ApartmentType = apartmentCreateRequest.ApartmentType,
            FloorNumber = apartmentCreateRequest.FloorNumber,
            ApartmentNumber = apartmentCreateRequest.ApartmentNumber,
            OwnerOrTenant = apartmentCreateRequest.OwnerOrTenant,
            BuildingId = building.Id,
            Building = building
        };
        await apartmentRepository.AddApartmentToBuildingAsync(apartment);
        unitOfWork.Commit();
        return ResponseDto<int>.Success(apartment.Id);
    }
    public async Task<ResponseDto<string>> AddUserToApartment(int apartmentId, User user)
    {
        try
        {
            await apartmentRepository.AddUserToApartmentAsync(apartmentId, user);
            await unitOfWork.CommitAsync();
            return ResponseDto<string>.Success(string.Empty);
        }
        catch (Exception e)
        {
            return ResponseDto<string>.Fail(e.Message);
        }
    }
    public async Task<ResponseDto<int?>> GetApartmentUserIdAsync(int apartmentId)
    {
        var userId = await apartmentRepository.GetApartmentUserIdAsync(apartmentId);
        return ResponseDto<int?>.Success(userId);
    }
}

using BuildingManagement.Entity;
using BuildingManagement.Model.Models.Admin;
using BuildingManagement.Model.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Service.Service.ApartmentServices
{
    public interface IApartmentService
    {
        Task<ResponseDto<int>> AddApartmentToBuilding(ApartmentCreateRequestDto apartmentCreateRequest);
        Task<ResponseDto<string>> AddUserToApartment(int apartmentId, User user);
    }
}

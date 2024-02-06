using AutoMapper;
using BuildingManagement.Entity.Entities;
using BuildingManagement.Model.Models.Admin;
using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Repository;
using BuildingManagement.Repository.Repository.AdminRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Service.Service.DuesServices
{
    public class DuesService(IMapper mapper,IDuesRepository duesRepository, IUnitOfWork unitOfWork) : IDuesService
    {
        public async Task<ResponseDto<string>> AssignDuesAsync(List<AssignDuesRequestDto> model)
        {
            try
            {
                var duesInfo = mapper.Map<List<Dues>>(model);
                var apartments = await duesRepository.GetAllApartmentsAsync(duesInfo!);

                var dues = new List<Dues>();

                foreach (var apartment in apartments)
                {
                    var due = new Dues
                    {
                        Amount = model.Where(m => m.ApartmentIds == apartment.Id).Select(m => m.Amount).FirstOrDefault(),
                        IsPaid = false,
                        ApartmentId = apartment.Id
                    };
                    dues.Add(due);
                }

                unitOfWork.Commit();
                return ResponseDto<string>.Success(string.Empty);
            }
            catch (Exception ex)
            {
                return ResponseDto<string>.Fail(ex.Message);
            }
            
        }
    }
}

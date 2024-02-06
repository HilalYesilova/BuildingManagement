using AutoMapper;
using BuildingManagement.Repository.Repository.AdminRepository;
using BuildingManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Model.Models.Admin;
using BuildingManagement.Entity.Entities;
using BuildingManagement.Repository.Repository.BillRepository;

namespace BuildingManagement.Service.Service.BillService
{
    public class BillService(IMapper mapper, IBillRepository billRepository, IUnitOfWork unitOfWork) : IBillService
    {
        public async Task<ResponseDto<string>> AddBillsAsync(AddBillRequestDto billRequest)
        {
            var bill = mapper.Map<Bill>(billRequest);
            var billValue = billRepository.AddBillToBuildingAsync(bill!);
            unitOfWork.Commit();
            if (billValue == null) return ResponseDto<string>.Fail(string.Empty);
            return ResponseDto<string>.Success(string.Empty);
        }
    }
}

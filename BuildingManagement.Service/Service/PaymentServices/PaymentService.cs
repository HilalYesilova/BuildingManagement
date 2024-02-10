using AutoMapper;
using BuildingManagement.Model.Models.Payments.ApartmentPaymentDto;
using BuildingManagement.Model.Models.Shared;
using BuildingManagement.Repository;
using BuildingManagement.Repository.Repository.BillRepository;
using BuildingManagement.Repository.Repository.PaymentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Service.Service.PaymentServis
{
    public class PaymentService(IMapper mapper, IPaymentRepository paymentRepository, IUnitOfWork unitOfWork) : IPaymentService
    {
        public async Task<ResponseDto<IEnumerable<ApartmentPaymentDto>>> GetApartmentsPayments()
        {
            var apartments = paymentRepository.GetApartmentsPaymentsAsync();
            var apartmentPayments = new List<ApartmentPaymentDto>();
            if(apartments == null) return ResponseDto<IEnumerable<ApartmentPaymentDto>>.Fail("Apartmanlara ait ödeme bulunamadı");
            foreach (var apartment in apartments.Result)
            {
                var apartmentPayment = new ApartmentPaymentDto
                {
                    ApartmentId = apartment.Id,
                    Payment = apartment.Payments.ToList()
                };

                apartmentPayments.Add(apartmentPayment);
            }
            return ResponseDto<IEnumerable<ApartmentPaymentDto>>.Success(apartmentPayments!);
        }
    }
}

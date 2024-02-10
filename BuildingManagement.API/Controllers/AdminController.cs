using BuildingManagement.Service.Service.TokenServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BuildingManagement.Model.Models.Admin;
using BuildingManagement.Service.Service.DuesServices;
using BuildingManagement.Service.Service.BillServices;
using BuildingManagement.Model.Models.Payments.ApartmentPaymentDto;
using BuildingManagement.Service.Service.PaymentServis;
using BuildingManagement.Model.Models.Debt;
using BuildingManagement.Service.Service.DebtServices;
using BuildingManagement.Service.Service.ApartmentServices;
using BuildingManagement.Service.Service.UserServices;

namespace BuildingManagement.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
[Authorize]
public class AdminController(IdentityService identityService, IDuesService duesService, IBillService billService, IPaymentService paymentService, IDebtService debtService, IApartmentService apartmentService, IUserService userService) : ControllerBase
{
    /// <summary>
    /// Yönetici, Apartman Dairelerini Sisteme Tek Tek Ekler
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> AddApartmentsToBuilding(ApartmentCreateRequestDto request)
    {
        var response = await apartmentService.AddApartmentToBuilding(request);
        if (response.AnyError) return BadRequest(response);

        return Created("", response);
    }

    /// <summary>
    /// Yönetici, Kullanıcı Oluşturarak Dairelere Atama işlemini Yapar
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateUser(UserCreateRequestDto request)
    {
        var response = await identityService.CreateUser(request);
        if (response.AnyError) return BadRequest(response);

        return Created("", response);
    }

    /// <summary>
    /// Yönetici, Kullanıcı Bilgilerini Günceller. Not: email ile arama işlemi gerçekleştirir.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequestDto request)
    {
        var response = await identityService.UpdateUser(request);

        if (response.AnyError) return BadRequest(response);

        return Created("", response);
    }


    /// <summary>
    /// Yönetici, Kullanıcıları Silebilir.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpDelete("{email}")]
    public async Task<IActionResult> DeleteUser(string email)
    {
        var response = await identityService.DeleteUser(email);

        if (response.AnyError) return BadRequest(response);

        return NoContent();
    }

    /// <summary>
    /// Yönetici,Daire başına ödenmesi gereken aidat bilgilerini toplu veya tek tek atama yapar.
    /// </summary>
    /// <param name="aidInformationList"></param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> AssignDuesToApartments(List<AssignDuesRequestDto> aidInformationList)
    {
        var response = await duesService.AssignDuesAsync(aidInformationList);
        if (response.AnyError) return BadRequest(response);

        return Created("", response);
    }

    /// <summary>
    /// Yönetici, Bina olarak ödenmesi gereken fatura bilgilerini aylık olarak girer. Sql trigger ile dolu olan Dairelere atama yapar
    /// </summary>
    /// <param name="buildingBill"></param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> EnterMonthlyBuildingBills(AddBillRequestDto buildingBill)
    {
        var response = await billService.AddBillsAsync(buildingBill);
        if (response.AnyError) return BadRequest(response);

        return Created("", response);
    }


    /// <summary>
    /// Yönetici, Dairelerin yapmış olduğu ödemeleri görebilir.
    /// </summary>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApartmentPaymentDto>>> GetApartmentsPayments()
    {
        var response = await paymentService.GetApartmentsPayments();
        if (response.AnyError) return BadRequest(response);

        return Ok(response);
    }

    /// <summary>
    /// Yönetici,Aylık ve Yıllık olarak daire başına borç durumunu görebilir
    /// </summary>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DebtResponseDto>>> ViewApartmentsDebts()
    {
        var response = await debtService.GetApartmentsDebts();
        if (response.AnyError) return BadRequest(response);

        return Ok(response);
    }

    /// <summary>
    /// Yönetici, düzenli ödeme yapan kullanıcıları görebilir (BONUS)
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> ViewRegularPayers()
    {
        var response = await userService.UserRegularPayment();
        if (response.AnyError) return BadRequest(response);

        return Ok(response);
    }
}


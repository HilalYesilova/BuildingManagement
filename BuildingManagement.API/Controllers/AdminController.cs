using BuildingManagement.Service.Service.TokenServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BuildingManagement.Model.Models.Admin;
using BuildingManagement.Service.Service.DuesServices;
using BuildingManagement.Service.Service.BillService;
using BuildingManagement.Model.Models.Payments.ApartmentPaymentDto;
using BuildingManagement.Service.Service.PaymentServis;
using BuildingManagement.Model.Models.Debt;
using BuildingManagement.Service.Service.DebtServices;

namespace BuildingManagement.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdminController(IdentityService identityService,IDuesService duesService,IBillService billService, IPaymentService paymentService, IDebtService debtService) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserCreateRequestDto request)
    {
        var response = await identityService.CreateUser(request);
        if (response.AnyError) return BadRequest(response);

        return Created("", response);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateUser([FromBody] UserCreateRequestDto request)
    {
        var response = await identityService.UpdateUser(request);

        if (response.AnyError) return BadRequest(response);

        return Created("", response);
    }

    [HttpDelete("{email}")]
    public async Task<IActionResult> DeleteUser(string email)
    {
        var response = await identityService.DeleteUser(email);

        if (response.AnyError) return BadRequest(response);

        return NoContent();
    }

    // Daire başına ödenmesi gereken aidat bilgilerini toplu veya tek tek atama yapma
    [HttpPost]
    public async Task<IActionResult> AssignDuesToApartments(List<AssignDuesRequestDto> aidInformationList)
    {
        var response = await duesService.AssignDuesAsync(aidInformationList);
        if (response.AnyError) return BadRequest(response);

        return Created("", response);
    }

    // Bina olarak ödenmesi gereken fatura bilgilerini aylık olarak girme
    [HttpPost]
    public async Task<IActionResult> EnterMonthlyBuildingBills(AddBillRequestDto buildingBill)
    {
        var response = await billService.AddBillsAsync(buildingBill);
        if (response.AnyError) return BadRequest(response);

        return Created("", response);
    }

    // Dairelerin yapmış olduğu ödemeleri görme
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApartmentPaymentDto>>> GetApartmentsPayments()
    {
        var response = await paymentService.GetApartmentsPayments();
        if (response.AnyError) return BadRequest(response);

        return Ok(response);
    }

    // Aylık ve Yıllık olarak daire başına borç durumunu görme
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DebtResponseDto>>> ViewApartmentsDebts()
    {
        
        var response = await debtService.GetApartmentsDebts();
        if (response.AnyError) return BadRequest(response);

        return Ok(response);
    }

    //// Düzenli ödeme yapan kullanıcıları görme (BONUS)
    //[HttpGet]
    //public async Task<IActionResult> viewRegularPayers()
    //{
       
    //    List<User> regularPayers = new ArrayList<>(); 
    //    return Ok();
    //}
}


using Azure.Core;
using BuildingManagement.Entity.Entities;
using BuildingManagement.Entity;
using BuildingManagement.Service.Service.TokenServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BuildingManagement.Model.Models.Admin;

namespace BuildingManagement.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdminController(IdentityService identityService) : ControllerBase
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
    public async Task<IActionResult> AssignDuesToApartments(@RequestBody List<DuesInformation> aidInformationList)
    {
        
        return Ok();
        
    }

    // Bina olarak ödenmesi gereken fatura bilgilerini aylık olarak girme
    [HttpPost]
    public async Task<IActionResult> enterMonthlyBuildingBills(@RequestBody BuildingBill buildingBill)
    {
       
        return Ok();
        
    }

    // Dairelerin yapmış olduğu ödemeleri görme
    [HttpGet]
    public async Task<IActionResult> viewApartmentPayments()
    {
        
        List<Payment> payments = new ArrayList<>(); 
        return Ok();
    }

    // Aylık ve Yıllık olarak daire başına borç durumunu görme
    [HttpGet]
    public async Task<IActionResult> viewApartmentDebts(@PathVariable Long apartmentId)
    {
        
        DebtStatus debtStatus = new DebtStatus(); 
        return Ok(debtStatus);
    }

    // Düzenli ödeme yapan kullanıcıları görme (BONUS)
    [HttpGet]
    public async Task<IActionResult> viewRegularPayers()
    {
       
        List<User> regularPayers = new ArrayList<>(); 
        return Ok();
    }
}


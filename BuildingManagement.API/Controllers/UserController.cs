using BuildingManagement.API.Filters;
using BuildingManagement.Entity;
using BuildingManagement.Model.Models.User;
using BuildingManagement.Service.Service.DebtServices;
using BuildingManagement.Service.Service.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BuildingManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "User")]
    [ApiVersion("1.0")]
    public class UserController(IUserService userService) : ControllerBase
    {

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UserDebtAndDuesInfoResponse>>> GetUserBillsAndDues(int userId)
        {
            var response = await userService.GetUserDebtAndDuesInfoAsync(userId);
            if (response.AnyError) return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("Pay")]
        [LogOnSuccess("wwwroot/paymentLogs", "paymentLogs.txt")]
        public async Task<ActionResult> MakePayment(UserPaymentRequestDto paymentRequest)
        {
            var response = await userService.MakePaymentAsync(paymentRequest);
            if (response.AnyError) return BadRequest(response);

            return Ok(response);
        }

    }
}

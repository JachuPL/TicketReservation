using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketReservation.Application.Account.Interfaces;
using TicketReservation.Application.Account.Models;

namespace TicketReservation.WebAPI.Account
{
    [Route("api")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<JwtDto>> PostLogin([FromBody] LoginRequest model)
        {
            JwtDto jwtToken = await _accountService.LoginAsync(model.Login, model.Password);
            return Ok(jwtToken);
        }
    }
}
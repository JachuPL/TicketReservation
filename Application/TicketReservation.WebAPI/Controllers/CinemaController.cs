using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TicketReservation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CinemaController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Guid> Create([FromBody] CinemaCreationRequest model)
        {
            return Guid.NewGuid();
        }
    }

    public class CinemaCreationRequest
    {
    }
}
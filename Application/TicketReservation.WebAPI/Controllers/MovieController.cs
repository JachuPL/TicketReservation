using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TicketReservation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Guid> Create([FromBody] MovieCreationRequest model)
        {
            return Guid.NewGuid();
        }
    }

    public class MovieCreationRequest
    {
    }
}
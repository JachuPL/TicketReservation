using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TicketReservation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShowController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Guid> Create([FromBody] ShowCreationRequest model)
        {
            return Guid.NewGuid();
        }
    }

    public class ShowCreationRequest
    {
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TicketReservation.WebAPI.Shows.Requests;

namespace TicketReservation.WebAPI.Shows
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShowsController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Guid> Create([FromBody] ShowCreationRequest model)
        {
            return Guid.NewGuid();
        }
    }
}
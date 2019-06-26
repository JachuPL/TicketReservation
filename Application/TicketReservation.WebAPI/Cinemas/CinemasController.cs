using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TicketReservation.WebAPI.Cinemas.Requests;

namespace TicketReservation.WebAPI.Cinemas
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CinemasController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Guid> Create([FromBody] CreateCinemaRequest model)
        {
            return Guid.NewGuid();
        }
    }
}
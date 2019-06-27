using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TicketReservation.WebAPI.Shows.Requests;

namespace TicketReservation.WebAPI.Shows
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ShowsController : ControllerBase
    {
        [Route("{id:guid}", Name = nameof(GetShowById))]
        public ActionResult GetShowById(Guid id)
        {
            return null;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post(CreateShowRequest model)
        {
            Guid guid = Guid.NewGuid();
            return CreatedAtRoute(nameof(GetShowById), new { id = guid }, guid);
        }
    }
}
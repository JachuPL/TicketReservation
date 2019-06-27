using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TicketReservation.WebAPI.Cinemas.Requests;

namespace TicketReservation.WebAPI.Cinemas
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CinemasController : ControllerBase
    {
        [Route("{id:guid}", Name = nameof(GetCinemaById))]
        public ActionResult GetCinemaById(Guid id)
        {
            return null;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post(CreateCinemaRequest model)
        {
            Guid guid = Guid.NewGuid();
            return CreatedAtRoute(nameof(GetCinemaById), new { id = guid }, guid);
        }
    }
}
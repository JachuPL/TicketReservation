using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TicketReservation.WebAPI.Movies.Requests;

namespace TicketReservation.WebAPI.Movies
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        [Route("{id:guid}", Name = nameof(GetMovieById))]
        public ActionResult GetMovieById(Guid id)
        {
            return null;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post(CreateMovieRequest model)
        {
            Guid guid = Guid.NewGuid();
            return CreatedAtRoute(nameof(GetMovieById), new { id = guid }, guid);
        }
    }
}
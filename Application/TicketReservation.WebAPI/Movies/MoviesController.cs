using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TicketReservation.WebAPI.Movies.Requests;

namespace TicketReservation.WebAPI.Movies
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MoviesController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Guid> Create([FromBody] CreateMovieRequest model)
        {
            return Guid.NewGuid();
        }
    }
}
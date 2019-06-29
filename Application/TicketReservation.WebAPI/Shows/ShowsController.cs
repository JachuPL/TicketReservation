using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketReservation.Application.Reservations.Interfaces;
using TicketReservation.Application.Reservations.Models;
using TicketReservation.Application.Shows.Requests;

namespace TicketReservation.WebAPI.Shows
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ShowsController : ControllerBase
    {
        private readonly IQueryReservations _reservationsQuerier;

        public ShowsController(IQueryReservations reservationsQuerier)
        {
            _reservationsQuerier = reservationsQuerier;
        }

        [HttpGet]
        [Route("{id:guid}", Name = nameof(GetShowById))]
        public ActionResult GetShowById(Guid id)
        {
            // TODO: only for Location purposes
            return null;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post(CreateShowRequest model)
        {
            Guid guid = Guid.NewGuid();
            return CreatedAtRoute(nameof(GetShowById), new { id = guid }, guid);
        }

        [HttpGet]
        [Route("{id:guid}/availableseats")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAvailableSeats(Guid id)
        {
            IEnumerable<Place> availableSeats = await _reservationsQuerier.GetAvailableSeats(id);
            return Ok(availableSeats);
        }
    }
}
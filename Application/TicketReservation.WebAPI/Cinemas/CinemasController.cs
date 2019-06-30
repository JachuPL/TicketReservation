using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TicketReservation.Application.Cinemas.Interfaces;
using TicketReservation.Application.Cinemas.Models;
using TicketReservation.Application.Shows.Requests;
using TicketReservation.WebAPI.Shows;

namespace TicketReservation.WebAPI.Cinemas
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CinemasController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;

        public CinemasController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpGet]
        [Route("{id:guid}", Name = nameof(GetCinemaById))]
        public ActionResult GetCinemaById(Guid id)
        {
            // NOTE: this was just defined only for route generation while POSTing new entity
            return null;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post(CreateCinemaRequest model)
        {
            Guid cinemaId = Guid.NewGuid();
            await _cinemaService.Add(cinemaId, model);

            return CreatedAtRoute(nameof(GetCinemaById), new { id = cinemaId }, cinemaId);
        }

        [HttpPost]
        [Route("{id:guid}/shows")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> AddShow(Guid id, CreateShowRequest model)
        {
            Guid showId = Guid.NewGuid();
            await _cinemaService.AddShow(id, showId, model);

            return CreatedAtRoute(nameof(ShowsController.GetShowById), new { id = showId }, showId);
        }
    }
}